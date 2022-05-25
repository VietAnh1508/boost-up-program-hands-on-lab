package com.example.actuator.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.actuate.health.Health;
import org.springframework.boot.actuate.health.HealthIndicator;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.SingleColumnRowMapper;
import org.springframework.stereotype.Component;

@Component
public class DbHealthIndicator implements HealthIndicator {

	@Autowired
	JdbcTemplate jdbcTemplate;

	@Override
	public Health health() {
		int errorCode = check();
		if (errorCode != 1) {
			return Health.down().withDetail("Error Code", 500).build();
		}

		return Health.up().build();
	}

	private int check() {
		List<Object> results = jdbcTemplate.query("select 1 from dual", new SingleColumnRowMapper<>());
		return results.size();
	}

}
