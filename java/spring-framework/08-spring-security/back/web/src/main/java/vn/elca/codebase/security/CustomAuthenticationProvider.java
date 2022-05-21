package vn.elca.codebase.security;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.AuthenticationProvider;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Component;

@Component
public class CustomAuthenticationProvider implements AuthenticationProvider {

	@Autowired
	private UserDetailsService userDetailsService;

	@Autowired
	private PasswordEncoder passwordEncoder;

	@Override
	public Authentication authenticate(final Authentication authentication) throws AuthenticationException {
		final String username = authentication.getName();
		final String password = (String) authentication.getCredentials();

		final SecurityUser userDetails = (SecurityUser) userDetailsService.loadUserByUsername(username);
		return checkPassword(userDetails, password);
	}

	private Authentication checkPassword(final SecurityUser user, final String rawPassword) {
		if (passwordEncoder.matches(rawPassword, user.getPassword())) {
			return new UsernamePasswordAuthenticationToken(
					user.getUsername(),
					user.getPassword(),
					user.getAuthorities()
			);
		} else {
			throw new BadCredentialsException("Bad credentials");
		}
	}

	@Override
	public boolean supports(final Class<?> aClass) {
		return UsernamePasswordAuthenticationToken.class.isAssignableFrom(aClass);
	}

}
