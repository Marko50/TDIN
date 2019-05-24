package org.apache.tomcat.maven.tomcat.controllers;

import org.apache.tomcat.maven.tomcat.controllers.GenericController;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;


public class OrderController extends GenericController{

    public OrderController(String tname) throws SQLException {
        super(tname);
    }

    public boolean insert(String email, int bookID, String status){
        String query = "INSERT INTO " + DB_NAME + "." + this.tableName + " (email, bookID, status) VALUES (?, ?, ?)";
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query);
            preparedStatement.setString(1, email);
            preparedStatement.setInt(2, bookID);
            preparedStatement.setString(3, status);
            preparedStatement.executeUpdate();
        } catch (SQLException e) {
            System.out.println("Error inserting product with params " + email + "  " + bookID + "  " + status + ":" + e.getMessage());
            return false;
        }
        return true;
    }
}