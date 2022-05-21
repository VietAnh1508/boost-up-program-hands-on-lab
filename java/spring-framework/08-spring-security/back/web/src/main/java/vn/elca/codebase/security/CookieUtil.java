package vn.elca.codebase.security;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpCookie;
import org.springframework.http.ResponseCookie;
import org.springframework.stereotype.Component;

@Component
public class CookieUtil {

	@Value("${cookie.expiration}")
	private int cookieExpirationInSeconds;

	public HttpCookie createCookie(String jwt) {
		return ResponseCookie.from("accessToken", jwt)
				.path("/")
				.maxAge(cookieExpirationInSeconds)
				.httpOnly(true)
				.build();
	}

}
