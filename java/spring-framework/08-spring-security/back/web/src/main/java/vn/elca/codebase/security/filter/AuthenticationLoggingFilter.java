package vn.elca.codebase.security.filter;

import java.io.IOException;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.stereotype.Component;
import org.springframework.web.filter.OncePerRequestFilter;

import lombok.extern.slf4j.Slf4j;

@Component
@Slf4j
public class AuthenticationLoggingFilter extends OncePerRequestFilter {

	@Override
	protected void doFilterInternal(final HttpServletRequest httpRequest, final HttpServletResponse httpResponse,
			final FilterChain filterChain) throws ServletException, IOException {
		final String requestId = httpRequest.getHeader("Request-Id");
		logger.info("Successfully authenticated request with id " + requestId);
		filterChain.doFilter(httpRequest, httpResponse);
	}

}
