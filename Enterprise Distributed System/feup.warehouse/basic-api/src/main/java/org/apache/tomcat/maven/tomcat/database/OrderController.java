package org.apache.tomcat.maven.tomcat.database;


import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;


public class OrderController extends DatabaseController{

    public OrderController(String tname) throws SQLException {
        super(tname);
    }

    public int insert(int id ,String email, int bookID, int quantity){
        String query = "INSERT INTO " + DB_NAME + "." + this.tableName + " (id, email, bookID, quantity) VALUES (?, ?, ?, ?)";
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query,Statement.RETURN_GENERATED_KEYS);
            preparedStatement.setInt(1, id);
            preparedStatement.setString(2, email);
            preparedStatement.setInt(3, bookID);
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
            System.out.println("Error inserting product with params " + email + "  " + bookID  + ":" + e.getMessage());
            return -1;
        }
    }

    public int update(int id, String state){
        String query = "UPDATE " + DB_NAME + "." + this.tableName + " SET state = ? WHERE id = ?";
        try {
            PreparedStatement preparedStatement = this.connection.prepareStatement(query,Statement.RETURN_GENERATED_KEYS);
            preparedStatement.setString(1, state);
            preparedStatement.setInt(2, id);
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
            System.out.println("Error inserting product no + " + id + " with state " + state + ": " + e.getMessage());
            return -1;
        }
    }
}