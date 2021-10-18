package se.frontendstrategy.userservice.registration;

import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.Setter;
import lombok.ToString;

@Getter
@Setter
@ToString
@EqualsAndHashCode
public class RegistrationRequest {

    private String firstName;
    private String lastName;
    private String email;
    private String password;
    private String address;
    private String phone;
}
