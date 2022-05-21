package vn.elca.timingservice;

import java.time.Duration;
import java.time.Instant;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.Signature;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Pointcut;

@Aspect
public class TimingAspect {

	@Pointcut("@annotation(vn.elca.timingservice.TrackTime)")
	public void measureTime() { }

	@Around("execution(* vn.elca.sampleapp.service.impl.*ServiceImpl.*()) || measureTime()")
	public Object measurePerformance(ProceedingJoinPoint joinPoint) throws Throwable {
		final Signature signature = joinPoint.getSignature();
		final String className = signature.getDeclaringTypeName();
		String methodName = signature.getName();
		System.out.println("Methods: " + className + "." + methodName + "(..) start execution");

		Instant start = Instant.now();

		Object result = joinPoint.proceed();

		Instant finish = Instant.now();
		long timeElapsed = Duration.between(start, finish).toMillis();
		System.out.println("/Methods: " + className + "." + methodName + "(..), execution time: " + timeElapsed + "ms");

		return result;
	}

}
