package queue;

import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;
import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.MessageListener;
import javax.jms.MessageProducer;
import javax.jms.Queue;
import javax.jms.Session;

import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.activemq.broker.BrokerFactory;
import org.apache.activemq.broker.BrokerService;
import org.fusesource.mqtt.cli.Listener;

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

    @Override
    public void onMessage(Message arg0) {
        System.out.println("Message received");
    }
}
