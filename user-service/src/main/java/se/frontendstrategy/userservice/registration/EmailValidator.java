package se.frontendstrategy.userservice.registration;

import org.springframework.stereotype.Service;

import java.util.function.Predicate;

@Service
public class EmailValidator implements Predicate<String> {
    @Override
    public boolean test(String s) {
        //we can filter any email that we do not want to be created in our database.
        if (s.endsWith("@gmail.com") || s.endsWith("@yahoo.com") || s.endsWith("@hotmail.com")
        || s.endsWith("@test.com"))
        return true;

        return false;
    }

}
