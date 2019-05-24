package org.apache.tomcat.maven.tomcat.controllers;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class BookController extends GenericController{

    public BookController(String tname) throws SQLException {
        super(tname);
    }

    public boolean updateBookStock(int bookID, int newStock) {
        String query = "UPDATE " + DB_NAME + "." + this.tableName + " SET stock = ? where id = ?;";
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query);
            preparedStatement.setInt(1, newStock);
            preparedStatement.setInt(2, bookID);
            preparedStatement.executeUpdate();
            return true;
        } catch (SQLException e) {
            System.out.println("Error updating book " + bookID + ". " + e.getMessage());
            return false;
        }
    }
}