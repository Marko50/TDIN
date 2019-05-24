package org.apache.tomcat.maven.tomcat.controllers;

import java.sql.ResultSet;

public interface FacadeControllerREST{
    
    public ResultSet findAll();

    public ResultSet find(int id);
}