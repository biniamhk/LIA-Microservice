package se.frontendstrategy.userservice.registration;

import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;
import se.frontendstrategy.userservice.security.PasswordEncoder;
import se.frontendstrategy.userservice.users.User;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(path="api/v1/")
@AllArgsConstructor
public class RegistrationController {

    private RegistrationService registrationService;
    private PasswordEncoder passwordEncoder;

    @PostMapping("/registration")
    public String registerUser(@RequestBody RegistrationRequest request) {
        return registrationService.registerUser(request);
    }

    @PostMapping("/registrationAdmin")
    public String registerAdmin(@RequestBody RegistrationRequest request) {
        return registrationService.registerAdmin(request);
    }

    @GetMapping(path = "confirm")
    public String confirmUser(@RequestParam("token") String token) {
        return registrationService.confirmToken(token);
    }

    @PostMapping(path = "/login")
    @ResponseBody
    public Object logInUser(@RequestBody RegistrationRequest request){
        Optional<User> users = registrationService.getUserByEmail(request.getEmail(), request.getPassword());
        List<User> userList = registrationService.getByEmail(request.getEmail());
        for(User user:userList) {
            if (passwordEncoder.bCryptPasswordEncoder().matches(request.getPassword(), user.getPassword())) {
                return userList;
            }
        }
            return users.orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Invalid login."));
    }

    @GetMapping("/users")
    public List<User> getAllUser(){
        return registrationService.getUsers();

    }

    @PutMapping(path = "/update/{email}")
    public User updateUser(@RequestBody RegistrationRequest request, @PathVariable String email){
        return registrationService.updateUser(request, email);
    }


   @DeleteMapping(path = "/delete/{email}")
    @ResponseStatus(HttpStatus.GONE)
   public void deleteUser(@PathVariable String email){
       registrationService.deleteByEmail(email);
   }
}