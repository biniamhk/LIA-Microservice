package se.frontendstrategy.userservice.emailvalidator;

import org.junit.jupiter.api.Test;
import se.frontendstrategy.userservice.registration.EmailValidator;
import se.frontendstrategy.userservice.users.User;
import se.frontendstrategy.userservice.users.UserRole;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;

public class EmailValidatorTest {

    EmailValidator emailVallidator =new EmailValidator();
    boolean valid=true;




    @Test
    void sendingValidEmailreturnsTrue() {
        User user = new User("Biniam", "Haile", "biniam@gmail.com",
            "password",
            "Styrbjörn", "123456", UserRole.ADMIN);
        assertThat(emailVallidator.test(user.getEmail())).isEqualTo(valid);

    }
    @Test
    void sendingInvalidEmailreturnsFalse(){
        User user = new User("Biniam", "Haile", "biniam@iths.se",
                "password",
                "Styrbjörn", "123456", UserRole.ADMIN);

        assertThat(emailVallidator.test(user.getEmail())).isEqualTo(!valid);
    }
}
