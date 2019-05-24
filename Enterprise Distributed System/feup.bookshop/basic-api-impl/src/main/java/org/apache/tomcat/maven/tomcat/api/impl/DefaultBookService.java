package org.apache.tomcat.maven.tomcat.api.impl;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.gson.Gson;

import org.apache.tomcat.maven.tomcat.models.Book;
import org.apache.tomcat.maven.tomcat.api.BookService;
import org.apache.tomcat.maven.tomcat.controllers.GenericController;
import org.springframework.stereotype.Service;

/**
 * @author Olivier Lamy
 */
@Service("bookService#default")
public class DefaultBookService implements BookService {

    public String getAllBooks() {
        Gson gson = new Gson();
        List<Book> list = new ArrayList<Book>();
        Map<String, Object> value = new HashMap<String,Object>();
        try {
            GenericController genericController = new GenericController("books");
            ResultSet resultSet = genericController.findAll();
            if (resultSet == null){
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
            while (resultSet.next()) {
                int id = resultSet.getInt("id");
                String title = resultSet.getString("title");
                float price = resultSet.getFloat("price");
                int stock = resultSet.getInt("stock");
                String author = resultSet.getString("author");
                list.add(new Book(id, title, price, stock, author));
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

    public String getBook(String id) {
        Gson gson = new Gson();
        List<Book> list = new ArrayList<Book>();
        Map<String, Object> value = new HashMap<String,Object>();
        try {
            int id_parsed = Integer.parseInt(id);
            GenericController genericController = new GenericController("books");
            ResultSet resultSet = genericController.find(id_parsed);
            if (resultSet == null){
                value.put("success", false);
                value.put("information", "500 Internal Server Error");
                return gson.toJson(value);
            }
            while (resultSet.next()) {
                int book_id = resultSet.getInt("id");
                String title = resultSet.getString("title");
                float price = resultSet.getFloat("price");
                int stock = resultSet.getInt("stock");
                String author = resultSet.getString("author");
                list.add(new Book(book_id, title, price, stock, author));

            }
        }catch (NumberFormatException e) {
            value.put("success", false);
            value.put("information", "400 Bad parameteres error" + e.getMessage());
            System.out.println("Error 404 Bad params:" + id + " when fetching book from the Database: " + e.getMessage());
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
   
}