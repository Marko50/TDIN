package org.apache.tomcat.maven.tomcat.api;

import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.apache.tomcat.maven.tomcat.models.Order;


@Path( "orders" )
public interface OrderService
{
    @POST
    @Produces({MediaType.APPLICATION_JSON})
    @Consumes({MediaType.APPLICATION_JSON})
    public String insertOrder(final Order order);

    @GET
    @Path("/{id}")
    @Produces({MediaType.APPLICATION_JSON})
    String getOrder(@PathParam("id") String id);
}