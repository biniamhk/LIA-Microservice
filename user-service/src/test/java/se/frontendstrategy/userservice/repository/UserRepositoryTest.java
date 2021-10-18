package se.frontendstrategy.userservice.repository;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import se.frontendstrategy.userservice.users.User;
import se.frontendstrategy.userservice.users.UserRepository;
import se.frontendstrategy.userservice.users.UserRole;

import static org.assertj.core.api.Assertions.assertThat;

import java.util.Optional;

@DataJpaTest
@AutoConfigureTestDatabase(replace= AutoConfigureTestDatabase.Replace.NONE)
public class UserRepositoryTest {

    @Autowired
    UserRepository repository;

    @Test
    void itShouldFindByEmail() {
        String email = "philip.mattsson@test.se";

        User Usr = new User(
                "Philip",
                "Mattsson",
                email,
                "password",
                "street69",
                "156206545",
                UserRole.USER);

        repository.save(Usr);

        Optional<User> userOptional = repository.findByEmail(email);

        assertThat(userOptional)
                .isPresent()
                .hasValueSatisfying(
                        c -> assertThat(c).isEqualTo(Usr));
    }

    @Test
    void itShouldNotFindByEmail(){
        String email = "philip.mattsson@test.se";

        Optional<User> userOptional = repository.findByEmail(email);

        assertThat(userOptional).isNotPresent();
    }

    @Test
    void ItShouldEnableUser(){
        String email = "philip.mattsson@test.se";

        User Usr = new User(
                "Philip",
                "Mattsson",
                email,
                "password",
                "street69",
                "156206545",
                UserRole.USER);

        repository.save(Usr);

        int userOptional = repository.enableUser(email);

        assertThat(userOptional).isEqualTo(1);

    }

    @Test
    void ItShouldNotEnableUser(){

        int userOptional = repository.enableUser(null);

        assertThat(userOptional).isNotEqualTo(1);
    }
}