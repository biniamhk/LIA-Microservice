FROM maven:latest
ENV APP_HOME=/app/
COPY user-service/pom.xml $APP_HOME
COPY user-service/src $APP_HOME/src/
WORKDIR $APP_HOME
RUN mvn package -DskipTests
ENV JAR_FILE=target/user-service.jar
RUN mv ${JAR_FILE} /user-service.jar
EXPOSE 8080
ENTRYPOINT ["java", "-jar", "/user-service.jar"]
