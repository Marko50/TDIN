package org.apache.tomcat.maven.tomcat.api;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;


/**
 * HelloService!
 */
@Path( "books" )
public interface BookService
{
    @GET
    @Produces( { MediaType.APPLICATION_JSON } )
    String getAllBooks();

    @GET
    @Path("/{id}")
    @Produces({MediaType.APPLICATION_JSON})
    String getBook(@PathParam("id") String id);
}