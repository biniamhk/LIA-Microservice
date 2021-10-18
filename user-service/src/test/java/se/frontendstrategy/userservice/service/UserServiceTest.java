package se.frontendstrategy.userservice.service;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.ArgumentCaptor;
import org.mockito.Captor;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import se.frontendstrategy.userservice.registration.token.ConfirmationTokenService;
import se.frontendstrategy.userservice.users.User;
import se.frontendstrategy.userservice.users.UserRepository;
import se.frontendstrategy.userservice.users.UserRole;
import se.frontendstrategy.userservice.users.UserService;

import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThatThrownBy;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.BDDMockito.given;
import static org.mockito.BDDMockito.then;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.never;

public class UserServiceTest{

    @Mock
    private UserRepository repository;

    @Mock
    private BCryptPasswordEncoder encoder;

    @Mock
    private ConfirmationTokenService tokenService;

    @Captor
    private ArgumentCaptor<User> userArgumentCaptor;

    private UserService service;

    @BeforeEach
    void setUp(){
        MockitoAnnotations.initMocks(this);
        service = new UserService(repository, encoder, tokenService);
    }

    @Test
    void itShouldLoadUserByUsername(){

        String email = "test@mail.com";

        User Usr = new User(
                "Philip",
                "Mattsson",
                email,
                "password",
                "street69",
                "156206545",
                UserRole.USER);

        given(repository.findByEmail(email)).willReturn(Optional.empty());

        given(encoder.encode(email)).willReturn(String.valueOf(true));

        service.signUpUser(Usr);

        repository.findByEmail("test@mail.com");

        then(repository).should().save(userArgumentCaptor.capture());
        User userArgumentCaptorValue = userArgumentCaptor.getValue();
        assertThat(userArgumentCaptorValue).isEqualTo(Usr);

    }

    @Test
    void itShouldSignUpUser(){

        String email = "test@mail.com";

        User Usr = new User(
                "Philip",
                "Mattsson",
                email,
                "password",
                "street69",
                "156206545",
                UserRole.USER);

        given(repository.findByEmail(email)).willReturn(Optional.empty());

        given(encoder.encode(email)).willReturn(String.valueOf(true));

        service.signUpUser(Usr);

        then(repository).should().save(userArgumentCaptor.capture());
        User userArgumentCaptorValue = userArgumentCaptor.getValue();
        assertThat(userArgumentCaptorValue).isEqualTo(Usr);
    }
}
