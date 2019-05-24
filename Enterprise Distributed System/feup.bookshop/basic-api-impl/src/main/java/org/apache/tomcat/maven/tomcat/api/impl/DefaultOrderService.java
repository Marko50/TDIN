package org.apache.tomcat.maven.tomcat.api.impl;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import com.google.gson.Gson;

import org.apache.tomcat.maven.tomcat.api.OrderService;
import org.apache.tomcat.maven.tomcat.controllers.BookController;
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
            String status = updateBookStock(resultSet);
            if(status.equals("Error")){
                value.put("success", false);
                value.put("information", "500 Internal Server Error. Error updating book stock for book "+ order.bookID);
                return gson.toJson(value);
            }
            int orderResponse = orderController.insert(order.email, bookIDParsed, status);
            if (orderResponse > 0) {
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


    private String updateBookStock(ResultSet book){
        try {
            BookController bookController = new BookController("books");
            int stock = book.getInt("stock");
            if ((stock - 1 ) >= 0) {
                int id = book.getInt("id");
                bookController.updateBookStock(id, stock - 1);
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

}
