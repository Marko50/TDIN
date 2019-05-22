package org.apache.tomcat.maven.tomcat.controllers;

import java.sql.ResultSet;

public interface FacadeControllerREST<T>{
    
    public ResultSet findAll();
}