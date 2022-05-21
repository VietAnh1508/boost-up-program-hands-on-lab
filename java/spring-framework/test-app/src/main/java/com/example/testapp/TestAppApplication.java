package com.example.testapp;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class TestAppApplication implements CommandLineRunner {

	@Autowired
	private MyService myService;

	public static void main(String[] args) {
		SpringApplication.run(TestAppApplication.class, args);
	}

	@Override
	public void run(final String... args) throws Exception {
		myService.doSomething();
	}

}
