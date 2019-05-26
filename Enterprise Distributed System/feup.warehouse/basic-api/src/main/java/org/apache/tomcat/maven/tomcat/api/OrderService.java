package org.apache.tomcat.maven.tomcat.api;


import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

/**
 * HelloService!
 */
@Path( "orders" )
public interface OrderService
{
    @GET
    @Produces( { MediaType.APPLICATION_JSON } )
    String getAllOrders( );
}
