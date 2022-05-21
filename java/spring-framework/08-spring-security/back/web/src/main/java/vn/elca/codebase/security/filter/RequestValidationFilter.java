package vn.elca.codebase.security.filter;

import java.io.IOException;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.stereotype.Component;
import org.springframework.web.filter.OncePerRequestFilter;

@Component
public class RequestValidationFilter extends OncePerRequestFilter {

	@Override
	protected void doFilterInternal(final HttpServletRequest httpRequest, final HttpServletResponse httpResponse,
			final FilterChain filterChain) throws ServletException, IOException {
		final String requestId = httpRequest.getHeader("Request-Id");
		if (requestId == null || requestId.isBlank()) {
			httpResponse.setStatus(HttpServletResponse.SC_BAD_REQUEST);
			return;
		}

		filterChain.doFilter(httpRequest, httpResponse);
	}

	@Override
	protected boolean shouldNotFilter(final HttpServletRequest request) throws ServletException {
		final String servletPath = request.getServletPath();
		if (servletPath.equals("/") || servletPath.startsWith("/h2-console")) {
			return true;
		}
		return super.shouldNotFilter(request);
	}

}
