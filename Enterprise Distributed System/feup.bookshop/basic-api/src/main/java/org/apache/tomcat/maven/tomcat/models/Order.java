package org.apache.tomcat.maven.tomcat.models;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class Order{
    public int id;
    @XmlElement public String email;
    @XmlElement public String bookID;
    public String state;

    public Order(){
        
    }

    public Order(int i, String e, String b, String s){
        this.id = i;
        this.email = e;
        this.bookID = b;
        this.state = s;
    }

}