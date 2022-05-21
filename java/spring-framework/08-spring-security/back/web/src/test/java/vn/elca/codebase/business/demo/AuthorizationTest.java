package vn.elca.codebase.business.demo;

import org.junit.Test;
import org.springframework.http.HttpStatus;
import org.springframework.security.test.context.support.WithMockUser;

import vn.elca.codebase.business.AbstractRestITTest;

public class AuthorizationTest extends AbstractRestITTest {

	@Test
	public void unAuthorizedUser_willBeRedirected() throws Exception {
		sendGetRequest("/service/common/sayHello/my-test", HttpStatus.FOUND.value()); // 302
	}

	@Test
	@WithMockUser(username = "john", authorities = { "READ", "WRITE" })
	public void userHasReadAuthority_canCallGetApi() throws Exception {
		sendGetRequest("/service/common/sayHello/my-test", HttpStatus.OK.value());
	}

	@Test
	@WithMockUser(username = "alice", authorities = { "READ" })
	public void userHasReadAuthority_canNotCallPostApi() throws Exception {
		sendPostRequest("/service/common/testPostApi", "", HttpStatus.UNAUTHORIZED.value());
	}

	@Test
	@WithMockUser(username = "john", authorities = { "READ", "WRITE" })
	public void userHasWriteAuthority_canCallPostApi() throws Exception {
		sendPostRequest("/service/common/testPostApi", "", HttpStatus.OK.value());
	}

	@Test
	@WithMockUser(username = "john", authorities = { "READ", "WRITE" })
	public void userHasDoesNotAuthority_canNotGetAllInfo() throws Exception {
		sendGetRequest("/service/common/getAllNames", HttpStatus.FORBIDDEN.value());
	}

	@Test
	@WithMockUser(username = "bob", authorities = { "READ", "VIEW_OTHER_USERS" })
	public void userHasAuthority_canGetAllInfo() throws Exception {
		sendGetRequest("/service/common/getAllNames", HttpStatus.OK.value());
	}

}
