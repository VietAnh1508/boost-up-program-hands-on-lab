package vn.elca.codebase.demo.impl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import vn.elca.codebase.demo.UserService;
import vn.elca.codebase.entity.User;
import vn.elca.codebase.exception.UserNotFoundException;
import vn.elca.codebase.repository.UserRepository;
import vn.elca.codebase.security.SecurityUser;

@Service
public class UserServiceImpl implements UserDetailsService, UserService {

	@Autowired
	private UserRepository userRepository;

	@Override
	public UserDetails loadUserByUsername(final String username) throws UsernameNotFoundException {
		final User user = userRepository.findUserByUsername(username)
				.orElseThrow(() -> new UsernameNotFoundException("Problem during authentication!"));

		return new SecurityUser(user);
	}

	@PreAuthorize("hasAuthority('VIEW_OTHER_USERS')")
	@Override
	public List<User> getAllUsers() {
		return userRepository.findAll();
	}

	@Override
	public User getUserById(final Long id) {
		return userRepository.findUserById(id)
				.orElseThrow(() -> new UserNotFoundException("User with id: " + id + " not found"));
	}

}
