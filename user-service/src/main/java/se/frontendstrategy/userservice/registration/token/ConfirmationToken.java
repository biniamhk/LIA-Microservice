package se.frontendstrategy.userservice.registration.token;

import org.hibernate.annotations.GenericGenerator;
import org.hibernate.annotations.OnDelete;
import se.frontendstrategy.userservice.users.User;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.time.LocalDateTime;
import java.util.UUID;

@Getter
@Setter
@NoArgsConstructor
@Entity
@Table(name="confirmation_token")
public class ConfirmationToken {

    @Id
    @GeneratedValue(generator = "uuid")
    @GenericGenerator(name = "uuid", strategy = "uuid2")
    private UUID id;

    @Column(nullable = false)
    private String token;

    @Column(nullable = false)
    private LocalDateTime createdAt;

    @Column(nullable = false)
    private LocalDateTime expiresAt;

    private LocalDateTime confirmedAt;

    @ManyToOne(  cascade = CascadeType.REMOVE
              )
    @JoinColumn(
            nullable = false,
            name = "user_id"
    )
    @OnDelete(action = org.hibernate.annotations.OnDeleteAction.CASCADE)
    private User Usr;

    public ConfirmationToken(String token,
                             LocalDateTime createdAt,
                             LocalDateTime expiresAt,
                             User Usr) {
        this.token = token;
        this.createdAt = createdAt;
        this.expiresAt = expiresAt;
        this.Usr = Usr;
    }
}
