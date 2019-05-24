package org.apache.tomcat.maven.tomcat.controllers;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class GenericController implements FacadeControllerREST {
    public static final String DB_NAME = "bookstore";
    public static final String DB_URL = "jdbc:mysql://localhost:3306/" + DB_NAME + "?useUnicode=true&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
    public static final String USER = "root";
    public static final String PASSWORD = "mysql";

    private String tableName;
    private Connection connection;

    public GenericController(String tname) throws SQLException{
        this.tableName = tname;
        this.connection = DriverManager.getConnection(DB_URL, USER, PASSWORD);     
    }

    public ResultSet findAll() {
        String query = "SELECT * FROM " + DB_NAME +"." + tableName;
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query);
            ResultSet set = preparedStatement.executeQuery();
            return set;
        } catch (SQLException e) {
            System.out.println("Error fetching books from the Database: " + e.getMessage());
            return null;
        }
    }

    public ResultSet find(int id) {
        String query = "SELECT * FROM " + DB_NAME + "." + tableName + " WHERE id=?";
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query);
            preparedStatement.setInt(1, id);
            ResultSet resultSet = preparedStatement.executeQuery();
            return resultSet;
        } catch (SQLException e) {
            System.out.println("Error fetching book with id=" + id + " from the Database: " + e.getMessage());
            return null;
        }
    }
}