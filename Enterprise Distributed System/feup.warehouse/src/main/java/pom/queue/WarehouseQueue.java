package pom.queue;

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




public class WarehouseQueue implements ServletContextListener, MessageListener {
    private Connection connection;

    @Override
    public void contextDestroyed(ServletContextEvent arg0) {
        System.out.println("Queue destroyed");
    }

    // Run this before web application is started
    @Override
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
;
    @Override
    public void onMessage(Message m) {
        TextMessage object = (TextMessage) m;
        try {
            String order = object.getText();
            System.out.println("Message received: " + order);
        } catch (JMSException e) {
            System.out.println("Error receiving order. " + e.getMessage());
        }
    }
}
