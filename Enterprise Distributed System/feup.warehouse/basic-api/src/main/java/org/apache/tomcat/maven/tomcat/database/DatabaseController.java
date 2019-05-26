package org.apache.tomcat.maven.tomcat.database;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;


public abstract class DatabaseController{

    public static final String DB_NAME = "warehouse";
    public static final String DB_URL = "jdbc:mysql://localhost:3306/" + DB_NAME + "?useUnicode=true&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
    public static final String USER = "root";
    public static final String PASSWORD = "mysql";

    protected String tableName;
    protected Connection connection;

    public DatabaseController(String tname) throws SQLException{
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

    public int delete(int id){
        String query = "DELETE FROM " + DB_NAME + "." + tableName + " WHERE id=?";
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query);
            preparedStatement.setInt(1, id);
            preparedStatement.executeQuery();
            return 0;
        } catch (SQLException e) {
            System.out.println("Error deleting book with id=" + id + " from the Database: " + e.getMessage());
            return -1;
        }
    }

}