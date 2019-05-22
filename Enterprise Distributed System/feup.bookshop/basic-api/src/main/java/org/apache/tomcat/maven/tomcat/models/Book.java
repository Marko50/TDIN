package org.apache.tomcat.maven.tomcat.models;

import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "books")
public class Book{
    public int Id;
    public String Title;
    public float Price;
    public int Stock;
    public String Author;

    public Book(int i , String t, float p, int s, String a){
        this.Id = i;
        this.Title = t;
        this.Price = p;
        this.Stock = s;
        this.Author = a;
    }
}