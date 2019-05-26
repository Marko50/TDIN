package org.apache.tomcat.maven.tomcat.api.impl;

import java.io.IOException;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.gson.Gson;

import org.apache.tomcat.maven.tomcat.api.OrderService;
import org.apache.tomcat.maven.tomcat.database.OrderController;
import org.apache.tomcat.maven.tomcat.objects.Order;
import org.codehaus.jettison.json.JSONException;
import org.codehaus.jettison.json.JSONObject;
import org.springframework.stereotype.Service;

@Service("orderService#default")
public class DefaultOrderService implements OrderService {

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
        Map<String, Object> value = new HashMap<String, Object>();
        try {
            if(!notifyStore(order)){
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
            OrderController genericController = new OrderController("orders");
            if (!genericController.delete(order.id)) {
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

    private boolean notifyStore(Order order) {
        try {
            JSONObject first = new JSONObject();
            JSONObject second = new JSONObject();
            URL url = new URL("http://localhost:9090/restServices/orders");
            HttpURLConnection con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("PUT");
            con.setDoOutput(true);
            con.setDoInput(true);
            con.setRequestProperty("Content-Type", "application/json");
            con.setRequestProperty("Accept", "application/json");
            first.put("id", order.id);
            first.put("bookID", order.bookID);
            first.put("email", order.email);
            Date currentDate = new Date();
            Calendar c = Calendar.getInstance();
            c.setTime(currentDate);
            c.add(Calendar.DATE, 2);
            Date nextDay = c.getTime();
            first.put("state", "Dispatch will occur at " + nextDay.toString());
            second.put("order", first);
            System.out.println(second.toString());
            OutputStream os = con.getOutputStream();
            byte[] input = second.toString().getBytes("utf-8");
            os.write(input, 0, input.length);
            int r = con.getResponseCode();
            System.out.println(r);
            os.close();
        } catch (MalformedURLException e) {
            System.out.println("Bookstore url is malformed: " + e.getMessage());
            return false;
        } catch(IOException e){
            System.out.println("Error opening http connection: " + e.getMessage());
            return false;
        }catch(JSONException e){
            System.out.println("Error JSON: " + e.getMessage());
            return false;
        }
        return true;
    }

}