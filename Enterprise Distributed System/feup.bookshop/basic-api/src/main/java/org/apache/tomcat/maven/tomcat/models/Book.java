package org.apache.tomcat.maven.tomcat.models;

import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class Book{
    public int id;
    public String title;
    public float price;
    public int stock;
    public String author;

    public Book(){
        
    }

    public Book(int i , String t, float p, int s, String a){
        this.id = i;
        this.title = t;
        this.price = p;
        this.stock = s;
        this.author = a;
    }
}