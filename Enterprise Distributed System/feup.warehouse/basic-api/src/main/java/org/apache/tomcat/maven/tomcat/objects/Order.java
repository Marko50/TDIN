package org.apache.tomcat.maven.tomcat.objects;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class Order implements Serializable{
    private static final long serialVersionUID = -3954868138677770828L;
    @XmlElement public int id;
    @XmlElement public String email;
    @XmlElement public String bookID;
    @XmlElement public String state;
    @XmlElement public String quantity;

    public Order(){
        
    }

    public Order(int i, String e, String b, String s, String quantity){
        this.id = i;
        this.email = e;
        this.bookID = b;
        this.state = s;
        this.quantity = quantity;
    }

}