package org.apache.tomcat.maven.tomcat.queue;

import java.sql.SQLException;

import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.MessageListener;
import javax.jms.Queue;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.tomcat.maven.tomcat.database.OrderController;

public class WarehouseQueue implements ServletContextListener, MessageListener {
    private Connection connection;

    public void contextDestroyed(ServletContextEvent arg0) {
        System.out.println("Queue destroyed");
    }

    // Run this before web application is started
    public void contextInitialized(ServletContextEvent arg0) {
        ConnectionFactory connectionFactory = new ActiveMQConnectionFactory("tcp://localhost:61616");
        try {
            connection = connectionFactory.createConnection();
            Session session = connection.createSession(false,Session.AUTO_ACKNOWLEDGE);
            Queue queue = session.createQueue("WarehouseQueue");
            MessageConsumer consumer = session.createConsumer(queue);
            consumer.setMessageListener(this);
            connection.start();
            System.out.println("Queue started");
        } catch (JMSException e) {
            System.out.println("Error initializing queue. " + e.getMessage());
        }
    }

    public void onMessage(Message m) {
        TextMessage object = (TextMessage) m;
        try {
            String order = object.getText();
            String[] orderParts = order.split(":");
            String id = orderParts[0];
            String email = orderParts[1];
            String bookID = orderParts[2];
            String quantity = orderParts[3];
            OrderController orderController = new OrderController("orders");
            orderController.insert(Integer.parseInt(id), email, Integer.parseInt(bookID), Integer.parseInt(quantity));
            System.out.println("Message received: " + order);
        } catch (JMSException e) {
            System.out.println("Error receiving order. " + e.getMessage());
        }catch(SQLException e){
            System.out.println("Error receiving order. " + e.getMessage());
        }
    }
}