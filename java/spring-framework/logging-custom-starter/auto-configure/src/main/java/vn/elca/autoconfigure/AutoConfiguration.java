package vn.elca.autoconfigure;

import org.springframework.boot.autoconfigure.condition.ConditionalOnClass;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import vn.elca.timingservice.TimingAspect;

@Configuration
//@ConditionalOnClass(TimingAspect.class)
public class AutoConfiguration {

	@Bean
	public TimingAspect timingAspect() {
		return new TimingAspect();
	}

}
