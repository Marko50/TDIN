package org.apache.tomcat.maven.tomcat.api;

import javax.ws.rs.POST;
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
    @POST
    @Path("/{email}/{bookID}/{status}")
    @Produces({MediaType.APPLICATION_JSON})
    public String insertOrder(@PathParam("email") String email, @PathParam("bookID") String bookID, @PathParam("status") String status);
}