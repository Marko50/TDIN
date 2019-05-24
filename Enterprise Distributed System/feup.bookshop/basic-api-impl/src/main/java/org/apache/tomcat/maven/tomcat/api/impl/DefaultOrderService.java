package org.apache.tomcat.maven.tomcat.api.impl;

import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

import com.google.gson.Gson;

import org.apache.tomcat.maven.tomcat.api.OrderService;
import org.apache.tomcat.maven.tomcat.controllers.OrderController;
import org.springframework.stereotype.Service;

/**
 * @author Olivier Lamy
 */
@Service( "orderService#default" )
public class DefaultOrderService
    implements OrderService
{

    public String insertOrder(String email, String bookID, String status) {
        Gson gson = new Gson();
        Map<String, Object> value = new HashMap<String,Object>();  
        try {
            int bookIDParsed = Integer.parseInt(bookID);
            OrderController orderController = new OrderController("orders");
            if (orderController.insert(email, bookIDParsed, status)) {
                value.put("success", true);
                return gson.toJson(value);
            }else{
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }    
        } catch (NumberFormatException e) {
            value.put("success", false);
            value.put("information", "400 Bad parameteres error " + e.getMessage());
            System.out.println("Error 404 Bad params:" + bookID + " when fetching book from the Database: " + e.getMessage());
            return gson.toJson(value);
        } catch (SQLException e) {
            value.put("success", false);
            value.put("information", "500 Internal Server Error" + e.getMessage());
            return gson.toJson(value);
        }
    }


    private boolean checkBookStock(){
        return true;
    }

}
