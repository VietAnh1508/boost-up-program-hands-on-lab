package vn.elca.codebase.business.demo;

import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import vn.elca.codebase.common.AbstractElcaServiceEndpoint;
import vn.elca.codebase.demo.ProjectService;
import vn.elca.codebase.demo.UserService;
import vn.elca.codebase.entity.User;

@RestController
@RequestMapping(AbstractElcaServiceEndpoint.COMMON_PATH)
@Slf4j
@RequiredArgsConstructor
public class HelloWorldServiceEndpoint extends AbstractElcaServiceEndpoint {
    private final ProjectService projectService;

    @Autowired
    private final UserService userService;
    
    @GetMapping("sayHello/{personName}")
    @ResponseBody
    public String helloWorld(@PathVariable String personName) {
        return String.format("Hello %s with %d projects", personName, projectService.demoCountProjects());
    }

    @PostMapping("/testPostApi")
    @ResponseBody
    public String testPostApi() {
        return "post api response";
    }

    @GetMapping("/getName")
    public String getMyName() {
        return userService.getUserById(1L).getUsername();
    }

    @GetMapping("/getAllNames")
    public List<String> getAllUsernames() {
        return userService.getAllUsers().stream().map(User::getUsername).collect(Collectors.toList());
    }

}
