package org.apache.tomcat.maven.tomcat.api.impl;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.JMSException;
import javax.jms.MessageProducer;
import javax.jms.Queue;
import javax.jms.Session;
import javax.jms.TextMessage;

import com.google.gson.Gson;

import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.tomcat.maven.tomcat.api.OrderService;
import org.apache.tomcat.maven.tomcat.controllers.BookController;
import org.apache.tomcat.maven.tomcat.controllers.GenericController;
import org.apache.tomcat.maven.tomcat.controllers.OrderController;
import org.apache.tomcat.maven.tomcat.models.Order;
import org.springframework.stereotype.Service;

/**
 * @author Olivier Lamy
 */
@Service( "orderService#default" )
public class DefaultOrderService
    implements OrderService
{

    public String insertOrder(final Order order) {
        Gson gson = new Gson();
        Map<String, Object> value = new HashMap<String,Object>();  
        try {
            int bookIDParsed = Integer.parseInt(order.bookID);
            int quantity = Integer.parseInt(order.quantity);
            OrderController orderController = new OrderController("orders");
            BookController bookController = new BookController("books");
            ResultSet resultSet = bookController.find(bookIDParsed);
            if(resultSet == null){
                value.put("success", false);
                value.put("information", "500 Internal Server Error. Error finding book " + order.bookID);
                return gson.toJson(value);
            }
            else if(!resultSet.next()){
                value.put("success", false);
                value.put("information", "404 Not found");
                return gson.toJson(value);
            }
            String status = updateBookStock(resultSet, Integer.parseInt(order.quantity));
            if(status.equals("Error")){
                value.put("success", false);
                value.put("information", "500 Internal Server Error. Error updating book stock for book "+ order.bookID);
                return gson.toJson(value);
            }
            int orderResponse = orderController.insert(order.email, bookIDParsed, status, quantity);
            if (orderResponse > 0) {
                if(status.equals("Waiting expedition")){
                    order.id = orderResponse;
                    if(!askWarehouse(order)){
                        value.put("success", false);
                        value.put("information", "500 Internal Server Error");
                        return gson.toJson(value);
                    }
                }
                value.put("success", true);
                value.put("information", "200 OK. Order created with " + order.email + " and " + status + " for book " + bookIDParsed);
                value.put("id", orderResponse);
                return gson.toJson(value);
            }else{
                value.put("success", false);
                value.put("information", "500 Internal Server Error. Error creating order with " + order.email + " and " + status + " for book " + bookIDParsed);
                return gson.toJson(value);
            }    
        } catch (NumberFormatException e) {
            value.put("success", false);
            value.put("information", "400 Bad parameteres error " + e.getMessage());
            System.out.println("Error 400 Bad params:" + order.bookID + " when fetching book from the Database: " + e.getMessage());
            return gson.toJson(value);
        } catch (SQLException e) {
            value.put("success", false);
            value.put("information", "500 Internal Server Error" + e.getMessage());
            return gson.toJson(value);
        }
    }
    
    public String getOrder(String id) {
        Gson gson = new Gson();
        List<Order> list = new ArrayList<Order>();
        Map<String, Object> value = new HashMap<String,Object>();
        try {
            int id_parsed = Integer.parseInt(id);
            GenericController genericController = new GenericController("orders");
            ResultSet resultSet = genericController.find(id_parsed);
            if (resultSet == null){
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
            while (resultSet.next()) {
                int orderID = resultSet.getInt("id");
                String email = resultSet.getString("email");
                int bookID = resultSet.getInt("bookID");
                String state = resultSet.getString("state");
                int quantity = resultSet.getInt("quantity");
                list.add(new Order(orderID, email, Integer.toString(bookID), state, Integer.toString(quantity)));
            }
            if(list.isEmpty()){
                value.put("success", false);
                value.put("information", "404 Not found");
                return gson.toJson(value);
            }
        }catch (NumberFormatException e) {
            value.put("success", false);
            value.put("information", "400 Bad parameteres error" + e.getMessage());
            System.out.println("Error 404 Bad params:" + id + " when fetching order from the Database: " + e.getMessage());
            return gson.toJson(value);
        }catch (SQLException e) {
            value.put("success", false);
            value.put("information", "500 Internal Server Error" + e.getMessage());
            return gson.toJson(value);
        }    
        value.put("success", true);
        value.put("information", list);
        return gson.toJson(value);
    }

    public String updateOrder(Order order) {
        System.out.println("order " + order.id + " " + order.email + " " + order.state + " " + order.bookID + " " + order.quantity);
        Gson gson = new Gson();
        Map<String, Object> value = new HashMap<String,Object>();
        try {
            OrderController orderController = new OrderController("orders");
            BookController bookController = new BookController("books");
            if (!orderController.update(order.id, Integer.parseInt(order.bookID), order.email, order.state, Integer.parseInt(order.quantity))) {
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
            if(!bookController.updateBookStock(Integer.parseInt(order.bookID) , 10)){
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value); 
            }
            value.put("success", true);
            value.put("information", order.id);
            return gson.toJson(value);
        } catch (SQLException e) {
            value.put("success", false);
            value.put("information", "500 Internal Server Error" + e.getMessage());
            return gson.toJson(value);
        }
    }

    public String updateOrderWarehouse(Order order) {
        System.out.println("order " + order.id + " " + order.email + " " + order.state + " " + order.bookID + " " + order.quantity);
        Gson gson = new Gson();
        Map<String, Object> value = new HashMap<String,Object>();
        try {
            OrderController orderController = new OrderController("orders");
            BookController bookController = new BookController("books");
            if (!orderController.update(order.id, Integer.parseInt(order.bookID), order.email, order.state, Integer.parseInt(order.quantity))) {
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
            int orderQuantity = Integer.parseInt(order.quantity) + 10;
            bookController.updateBookStock(Integer.parseInt(order.bookID), orderQuantity);
            value.put("success", true);
            value.put("information", order.id);
            return gson.toJson(value);
        } catch (SQLException e) {
            value.put("success", false);
            value.put("information", "500 Internal Server Error" + e.getMessage());
            return gson.toJson(value);
        }
    }

    public String getAllOrders() {
        Gson gson = new Gson();
        List<Order> list = new ArrayList<Order>();
        Map<String, Object> value = new HashMap<String, Object>();
        try {
            OrderController genericController = new OrderController("orders");
            ResultSet resultSet = genericController.findAll();
            if (resultSet == null) {
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
            while (resultSet.next()) {
                int id = resultSet.getInt("id");
                String email = resultSet.getString("email");
                int bookID = resultSet.getInt("bookID");
                String state = resultSet.getString("state");
                int quantity = resultSet.getInt("quantity");
                list.add(new Order(id, email, Integer.toString(bookID), state, Integer.toString(quantity)));
            }
        } catch (SQLException e) {
            value.put("success", false);
            value.put("information", "500 Internal Server Error" + e.getMessage());
            return gson.toJson(value);
        }
        value.put("success", true);
        value.put("information", list);
        return gson.toJson(value);
    }


    private String updateBookStock(ResultSet book, int quantity){
        try {
            BookController bookController = new BookController("books");
            int stock = book.getInt("stock");
            if ((stock - quantity ) >= 0) {
                int id = book.getInt("id");
                bookController.updateBookStock(id, stock - quantity);
                Date currentDate = new Date();
                Calendar c = Calendar.getInstance();
                c.setTime(currentDate);
                c.add(Calendar.DATE, 1);
                Date nextDay = c.getTime();
                return "Dispached at " + nextDay.toString();
            }
            else return "Waiting expedition";
        } catch (SQLException e) {
            System.out.print("Error updating stock of book. " + e.getMessage());
            return "Error";
        }
    }

    private boolean askWarehouse(Order order){
        ConnectionFactory connectionFactory = new ActiveMQConnectionFactory("tcp://localhost:61616");
        try {
            Connection connection = connectionFactory.createConnection();
            Session session = connection.createSession(false,Session.AUTO_ACKNOWLEDGE);
            Queue queue = session.createQueue("WarehouseQueue");
            MessageProducer messageProducer = session.createProducer(queue);
            TextMessage textMessage = session.createTextMessage();
            int orderQuantity = Integer.parseInt(order.quantity) + 10;
            textMessage.setText(order.id + ":" + order.email + ":" + order.bookID+ ":" + orderQuantity);
            messageProducer.send(textMessage);
            return true;
        } catch (JMSException e) {
            System.out.println("Error initializing queue. " + e.getMessage());
            return false;
        }
    }

    

    
}
