package vn.elca.sampleapp.service.impl;

import org.springframework.stereotype.Service;

import vn.elca.sampleapp.service.HelloService;

@Service
public class HelloServiceImpl implements HelloService {

	@Override
	public void printHello() {
		System.out.println("Hello world");
	}

}
