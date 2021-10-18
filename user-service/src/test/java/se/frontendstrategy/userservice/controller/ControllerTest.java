package se.frontendstrategy.userservice.controller;


import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import javax.servlet.Filter.*;

import org.mockito.*;
import se.frontendstrategy.userservice.email.EmailSender;
import se.frontendstrategy.userservice.registration.EmailValidator;
import se.frontendstrategy.userservice.registration.RegistrationController;
import se.frontendstrategy.userservice.registration.RegistrationService;
import se.frontendstrategy.userservice.registration.token.ConfirmationTokenService;
import se.frontendstrategy.userservice.users.User;
import se.frontendstrategy.userservice.users.UserRole;
import se.frontendstrategy.userservice.users.UserService;
import static org.assertj.core.api.AssertionsForClassTypes.assertThat;
import static org.junit.jupiter.api.Assertions.assertFalse;

public class ControllerTest {
    @Mock
    private EmailSender emailSender;

    @Mock
    private EmailValidator emailValidator;

    @Mock
    private ConfirmationTokenService tokenService;

    @Captor
    private ArgumentCaptor<User> userArgumentCaptor;

    @Mock
    private UserService service;

    private RegistrationController registrationController;


//    @BeforeEach
//    void setUp(){
//        MockitoAnnotations.initMocks(this);
//       registrationController = new RegistrationController(new RegistrationService(service,emailValidator,tokenService,emailSender));
//    }
//
//
//    @Test
//    void callingUsersReturnAllUser() {
//        User user1 = new User("Noah", "Biniam", "noah@gmail.com", "password", "street 1",
//                "0790165443", UserRole.ADMIN);
//        var user = registrationController.getAllUser();
//        assertThat(user.contains("noah@gmail.com"));
//
//    }
//
//
//
//    @Test
//    void callingUsersUsingInvalidEmailReturnNothing() {
//        User user1 = new User("Noah", "Biniam", "noah@gmail.com", "password", "street 1",
//                "0790165443", UserRole.ADMIN);
//        var user = registrationController.getAllUser();
//        assertFalse(user.contains("biniam@gmail.com"));
//
//    }
}
