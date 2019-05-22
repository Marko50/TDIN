package org.apache.tomcat.maven.tomcat.api.impl;

import java.util.ArrayList;
import java.util.List;

import com.google.gson.Gson;

import org.apache.tomcat.maven.tomcat.models.Book;
import org.apache.tomcat.maven.tomcat.api.BookService;
import org.springframework.stereotype.Service;

/**
 * @author Olivier Lamy
 */
@Service("bookService#default")
public class DefaultBookService implements BookService {

    public String getAllBooks() {
        Gson gson = new Gson();
        List<Book> list = new ArrayList<Book>();
        list.add(new Book(1, "Title", 35, 12, "Author"));
        return gson.toJson(list);
    }
   
}