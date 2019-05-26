package org.apache.tomcat.maven.tomcat.api.impl;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.gson.Gson;

import org.apache.tomcat.maven.tomcat.api.OrderService;
import org.apache.tomcat.maven.tomcat.database.OrderController;
import org.apache.tomcat.maven.tomcat.objects.Order;
import org.springframework.stereotype.Service;

@Service( "orderService#default" )
public class DefaultOrderService implements OrderService{

    public String getAllOrders() {
        Gson gson = new Gson();
        List<Order> list = new ArrayList<Order>();
        Map<String, Object> value = new HashMap<String,Object>();
        try {
            OrderController genericController = new OrderController("orders");
            ResultSet resultSet = genericController.findAll();
            if (resultSet == null){
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
            while (resultSet.next()) {
                int id = resultSet.getInt("id");
                String email = resultSet.getString("email");
                int bookID = resultSet.getInt("bookID");
                String state = resultSet.getString("state");
                list.add(new Order(id, email, Integer.toString(bookID), state));
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

    public String deleteOrder(Order order) {
        Gson gson = new Gson();
        Map<String, Object> value = new HashMap<String,Object>();
        try {
            OrderController genericController = new OrderController("orders");
            if(!genericController.delete(order.id) ){
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
        } catch (SQLException e) {
            value.put("success", false);
            value.put("information", "500 Internal Server Error" + e.getMessage());
            return gson.toJson(value);
        }    
        value.put("success", true);
        return gson.toJson(value);
    }

}