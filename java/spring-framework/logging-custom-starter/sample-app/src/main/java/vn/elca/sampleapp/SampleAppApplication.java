package vn.elca.sampleapp;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import vn.elca.sampleapp.service.HelloService;

@SpringBootApplication
public class SampleAppApplication implements CommandLineRunner {

	@Autowired
	private HelloService helloService;

	public static void main(String[] args) {
		SpringApplication.run(SampleAppApplication.class, args);
	}

	@Override
	public void run(final String... args) throws Exception {
		helloService.printHello();
	}

}
