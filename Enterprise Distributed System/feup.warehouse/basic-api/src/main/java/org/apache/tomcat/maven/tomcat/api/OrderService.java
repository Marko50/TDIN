package org.apache.tomcat.maven.tomcat.api;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.apache.tomcat.maven.tomcat.objects.Order;

/**
 * HelloService!
 */
@Path( "orders" )
public interface OrderService
{
    @GET
    @Produces( { MediaType.APPLICATION_JSON } )
    String getAllOrders();

    @DELETE
    @Produces({MediaType.APPLICATION_JSON})
    @Consumes({MediaType.APPLICATION_JSON})
    String deleteOrder(final Order order);
}
