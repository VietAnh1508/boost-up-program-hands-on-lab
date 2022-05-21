package vn.elca.codebase;

import java.io.OutputStream;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.annotation.Order;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.security.access.AccessDeniedException;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.builders.WebSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.web.access.AccessDeniedHandler;
import org.springframework.security.web.authentication.www.BasicAuthenticationFilter;
import org.springframework.security.web.csrf.CookieCsrfTokenRepository;
import org.springframework.security.web.csrf.CsrfException;

import com.fasterxml.jackson.databind.ObjectMapper;

import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import vn.elca.codebase.common.AbstractElcaServiceEndpoint;
import vn.elca.codebase.common.ExceptionHandlingController;
import vn.elca.codebase.common.constants.CodeBaseConstants;
import vn.elca.codebase.security.CustomAuthenticationProvider;
import vn.elca.codebase.security.CustomAuthenticationSuccessHandler;
import vn.elca.codebase.security.SecurityUtil;
import vn.elca.codebase.security.filter.AuthenticationLoggingFilter;
import vn.elca.codebase.security.filter.JwtAuthenticationFilter;
import vn.elca.codebase.security.filter.RequestValidationFilter;

@Configuration
@EnableWebSecurity
@EnableGlobalMethodSecurity(prePostEnabled = true)
@Slf4j
@Order(3)
@RequiredArgsConstructor
public class CodeBaseApiSecurityConfig extends WebSecurityConfigurerAdapter {

//    private final CodeBaseDummyBasicAuthenticationFilter codeBaseDummyBasicAuthenticationFilter;
    private final ObjectMapper objectMapper;

    @Autowired
    private CustomAuthenticationProvider authenticationProvider;

    @Autowired
    private CustomAuthenticationSuccessHandler authenticationSuccessHandler;

    @Autowired
    private RequestValidationFilter requestValidationFilter;

    @Autowired
    private JwtAuthenticationFilter jwtAuthenticationFilter;

    @Autowired
    private AuthenticationLoggingFilter authenticationLoggingFilter;
    
    @Override
    protected final void configure(AuthenticationManagerBuilder auth) {
        // no authentication manager: already done by some filters
        auth.authenticationProvider(authenticationProvider);
    }
    
    @Override
    protected void configure(HttpSecurity http) throws Exception {
        AccessDeniedHandler accessDeniedHandler = accessDeniedHandler();
        http
                .formLogin()
                .successHandler(authenticationSuccessHandler)
           .and()
                .addFilterBefore(jwtAuthenticationFilter, BasicAuthenticationFilter.class)
                .addFilterBefore(requestValidationFilter, JwtAuthenticationFilter.class)
//                .addFilterAt(codeBaseDummyBasicAuthenticationFilter, BasicAuthenticationFilter.class)
                .addFilterAfter(authenticationLoggingFilter, BasicAuthenticationFilter.class)
                .headers().frameOptions().sameOrigin()
           .and()
                .csrf().csrfTokenRepository(CookieCsrfTokenRepository.withHttpOnlyFalse())
                .ignoringAntMatchers(AbstractElcaServiceEndpoint.CSRF_IGNORE_PATH.toArray(new String[]{}));
        
        configureAuthorization(http, accessDeniedHandler);
        log.debug("Completed init of {}", getClass().getName());
    }
    
    private void configureAuthorization(HttpSecurity http, AccessDeniedHandler accessDeniedHandler) throws Exception {
        http.authorizeRequests()
                .mvcMatchers(HttpMethod.GET, "/**").hasAnyAuthority("READ", "WRITE")
                .mvcMatchers(HttpMethod.POST, "/**").hasAuthority("WRITE")
                .anyRequest().authenticated()
            .and()
                .exceptionHandling().accessDeniedHandler(accessDeniedHandler)
            // note: in case of authentication failure, IamAuthenticationSpringFilter.doAuthentication() will still
            // create a session. (this is not really an issue though)
            .and()
                .sessionManagement().sessionCreationPolicy(SessionCreationPolicy.STATELESS);
    }
    
    private AccessDeniedHandler accessDeniedHandler() {
        return (HttpServletRequest request, HttpServletResponse response, AccessDeniedException accessDeniedException) -> {
            if (accessDeniedException instanceof CsrfException) {
                log.warn("Csrf validation failed for user '{}'", SecurityUtil.currentUsername(), accessDeniedException);
                try (OutputStream os = response.getOutputStream()) {
                    response.setStatus(HttpStatus.BAD_REQUEST.value());
                    os.write(ExceptionHandlingController
                            .serverErrorResponseFor(HttpStatus.BAD_REQUEST, "Csrf validation error occurred", objectMapper)
                            .getBytes(CodeBaseConstants.PROJECT_ENCODING));
                }
            } else {
                log.error("Access denied.", accessDeniedException);
                try (OutputStream os = response.getOutputStream()) {
                    response.setStatus(HttpStatus.UNAUTHORIZED.value());
                    os.write(ExceptionHandlingController
                            .serverErrorResponseFor(HttpStatus.UNAUTHORIZED, "Authorization error occurred", objectMapper)
                            .getBytes(CodeBaseConstants.PROJECT_ENCODING));
                }
            }
        };
    }

    @Override
    public void configure(final WebSecurity web) throws Exception {
        web.ignoring().antMatchers("/h2-console/**");
    }

    @Bean
    public BCryptPasswordEncoder bCryptPasswordEncoder() {
        return new BCryptPasswordEncoder();
    }

}
