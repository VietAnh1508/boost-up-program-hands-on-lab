package vn.elca.codebase.demo;

import java.util.List;

import vn.elca.codebase.entity.User;

public interface UserService {

	List<User> getAllUsers();

	User getUserById(final Long id);

}
