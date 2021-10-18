package se.frontendstrategy.userservice.users;

import com.rabbitmq.client.*;

import java.io.IOException;
import java.time.LocalDateTime;
import java.util.concurrent.TimeoutException;

public class RabbitMQ {

    public static void sender(String username, String userId) throws IOException, TimeoutException {

        ConnectionFactory factory = new ConnectionFactory();
        factory.setPort(5672);
        factory.setHost("RabbitMqManager");

        try(Connection connection = factory.newConnection()) {

            Channel channel = connection.createChannel();
            channel.queueDeclare("findoutOne", false, false, false, null);
            String message = username + ", " + userId + ", " + LocalDateTime.now();
            channel.basicPublish("", "findoutOne", false, null, message.getBytes());

            //consuming data from rabbitmq
            channel.basicConsume("findoutOne", true, (consumerTag, messages) -> {
                String fromRabbitmq = new String(messages.getBody(), "UTF-8");
                System.out.println("======> Hello from Rabbitmq i send this message:  " + fromRabbitmq);

            }, consumerTag -> {

            });
        }
    }
}
