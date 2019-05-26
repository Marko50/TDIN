package org.apache.tomcat.maven.tomcat.controllers;

import org.apache.tomcat.maven.tomcat.controllers.GenericController;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;


public class OrderController extends GenericController{

    public OrderController(String tname) throws SQLException {
        super(tname);
    }

    public int insert(String email, int bookID, String status, int quantity){
        String query = "INSERT INTO " + DB_NAME + "." + this.tableName + " (email, bookID, state, quantity) VALUES (?, ?, ?, ?)";
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query,Statement.RETURN_GENERATED_KEYS);
            preparedStatement.setString(1, email);
            preparedStatement.setInt(2, bookID);
            preparedStatement.setString(3, status);
            preparedStatement.setInt(4, quantity);
            if(preparedStatement.executeUpdate() > 0){
                ResultSet rs = preparedStatement.getGeneratedKeys();
                if(rs.next())
                    return rs.getInt(1);
                else return 0;    
            }
            else{
                return 0;
            }
        } catch (SQLException e) {
            System.out.println("Error inserting product with params " + email + "  " + bookID + "  " + status + ":" + e.getMessage());
            return -1;
        }
    }

    public boolean update(int id, int bookID, String email, String state, int quantity){
        String query = "UPDATE " + DB_NAME + "." + this.tableName + " SET email = ? , state = ? , bookID = ?, quantity = ? WHERE id = ?";
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query,Statement.RETURN_GENERATED_KEYS);
            preparedStatement.setString(1, email);
            preparedStatement.setString(2, state);
            preparedStatement.setInt(3, bookID);
            preparedStatement.setInt(4, quantity);
            preparedStatement.setInt(5, id);
            preparedStatement.executeUpdate();
            return true;
        } catch (SQLException e) {
            System.out.println("Error updating product no + " + id + ". " + e.getMessage());
            return false;
        }
    }
}