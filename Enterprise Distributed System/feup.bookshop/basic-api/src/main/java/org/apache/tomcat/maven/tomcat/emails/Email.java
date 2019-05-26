package org.apache.tomcat.maven.tomcat.emails;

import java.util.Properties;
import javax.mail.*;
import javax.mail.internet.*;
// import javax.activation.*;

public class Email {
     // Get system properties
    private Properties properties;
    private Session session;
    private String sender = "feuptdinbookstore@gmail.com";
    private String receiver;
    
    public Email(String rec){
        this.receiver = rec;
        this.properties = System.getProperties();
        this.properties.put("mail.smtp.host", "smtp.gmail.com");
        this.properties.put("mail.smtp.socketFactory.port", "465");
        this.properties.put("mail.smtp.socketFactory.class",
                "javax.net.ssl.SSLSocketFactory");
        this.properties.put("mail.smtp.auth", "true");
        this.properties.put("mail.smtp.port", "465");
        this.session = Session.getDefaultInstance(this.properties,
        new javax.mail.Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(sender,"feuptdinbookstore123");
            }
        });
    }

    public boolean sendEmail(String messageEmail){
        try {
            // Create a default MimeMessage object.
            MimeMessage message = new MimeMessage(session);
            // Set From: header field of the header.
            message.setFrom(new InternetAddress(sender));
            // Set To: header field of the header.
            message.addRecipient(Message.RecipientType.TO, new InternetAddress(receiver));
            // Set Subject: header field
            message.setSubject("Bookstore order email");
            // Now set the actual message
            message.setText(messageEmail);
            // Send message
            Transport.send(message);
            return true;
         } catch (MessagingException mex) {
            System.out.println("Error sending message. " + mex.getMessage() );
            return false;
         }
    }
}