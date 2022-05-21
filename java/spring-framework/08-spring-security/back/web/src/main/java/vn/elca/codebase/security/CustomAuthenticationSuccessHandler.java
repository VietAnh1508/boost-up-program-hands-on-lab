package vn.elca.codebase.security;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.Authentication;
import org.springframework.security.web.authentication.AuthenticationSuccessHandler;
import org.springframework.stereotype.Component;

import com.google.common.net.HttpHeaders;

@Component
public class CustomAuthenticationSuccessHandler implements AuthenticationSuccessHandler {

	@Autowired
	private JwtProvider jwtProvider;

	@Autowired
	private CookieUtil cookieUtil;

	@Override
	public void onAuthenticationSuccess(final HttpServletRequest request, final HttpServletResponse response,
			final Authentication authentication) throws IOException, ServletException {
		final String jwt = jwtProvider.generateToken(authentication);
		response.setHeader(HttpHeaders.SET_COOKIE, cookieUtil.createCookie(jwt).toString());
		response.sendRedirect("/service/common/application-context");
	}

}
