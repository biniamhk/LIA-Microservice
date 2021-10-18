package se.frontendstrategy.userservice.users;

import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.server.ResponseStatusException;
import se.frontendstrategy.userservice.registration.RegistrationRequest;
import se.frontendstrategy.userservice.registration.token.ConfirmationToken;
import se.frontendstrategy.userservice.registration.token.ConfirmationTokenService;

import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Service
@AllArgsConstructor
public class UserService implements UserDetailsService {

    private final static String USER_NOT_FOUND_MSG = "User with email %s not found";

    private final UserRepository repository;
    private final BCryptPasswordEncoder bCryptPasswordEncoder;
    private final ConfirmationTokenService confirmationTokenService;

    @Override
    public UserDetails loadUserByUsername(String email) throws UsernameNotFoundException {
        return repository.findByEmail(email)
                .orElseThrow(()
                        -> new UsernameNotFoundException(
                                String.format(USER_NOT_FOUND_MSG, email)));
    }

    public String signUpUser(User Usr) {
        boolean userExists = repository
                .findByEmail(Usr.getEmail())
                .isPresent();

        if (userExists) {
            throw new IllegalStateException("email already taken");
        }

       String encodedPassword = bCryptPasswordEncoder
               .encode(Usr.getPassword());

       Usr.setPassword(encodedPassword);

        repository.save(Usr);

        String token = UUID.randomUUID().toString();

        ConfirmationToken confirmationToken = new ConfirmationToken(
                token,
                LocalDateTime.now(),
                LocalDateTime.now().plusHours(24),
                Usr
        );

        confirmationTokenService.saveConfirmationToken(
                confirmationToken);

        return token;
    }

    public void enableUser(String email){
        repository.enableUser(email);
    }

    public Optional<User> getUserByEmail(String email, String password){
        return repository.findByEmailAndPassword(email, password);
    }

    public List<User> getAllUsers(){
        return repository.findAll();
    }

    @Transactional
    public void deleteUserByEmail(String email) {
        repository.deleteUserByEmail(email);
    }

    public List<User> getByEmail(String email) {
        return repository.findUsersByEmail(email);
    }

    public User updateUser(RegistrationRequest request, String email) {
        Optional<User> user = repository.findByEmail(email);
        if(user.isPresent() && request.getFirstName() != null &&
                request.getLastName() != null &&
                request.getPassword() != null &&
                request.getAddress() != null  &&
                request.getPhone() != null){
            User updateUser = user.get();

                updateUser.setFirstName(request.getFirstName());
                updateUser.setLastName(request.getLastName());
                updateUser.setPassword(request.getPassword());
                updateUser.setAddress(request.getAddress());
                updateUser.setPhone(request.getPhone());
            return repository.save(updateUser);
        }else {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Email: " + email
                    + " not found or some data is missing");
        }
    }
}
