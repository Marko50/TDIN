
package apm.feup.org.ws;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="vals" type="{http://org.feup.apm/ws}ArrayOfDouble" minOccurs="0"/>
 *         &lt;element name="mx" type="{http://www.w3.org/2001/XMLSchema}double"/>
 *         &lt;element name="mn" type="{http://www.w3.org/2001/XMLSchema}double"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "vals",
    "mx",
    "mn"
})
@XmlRootElement(name = "Maxmin")
public class Maxmin {

    protected ArrayOfDouble vals;
    protected double mx;
    protected double mn;

    /**
     * Gets the value of the vals property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfDouble }
     *     
     */
    public ArrayOfDouble getVals() {
        return vals;
    }

    /**
     * Sets the value of the vals property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfDouble }
     *     
     */
    public void setVals(ArrayOfDouble value) {
        this.vals = value;
    }

    /**
     * Gets the value of the mx property.
     * 
     */
    public double getMx() {
        return mx;
    }

    /**
     * Sets the value of the mx property.
     * 
     */
    public void setMx(double value) {
        this.mx = value;
    }

    /**
     * Gets the value of the mn property.
     * 
     */
    public double getMn() {
        return mn;
    }

    /**
     * Sets the value of the mn property.
     * 
     */
    public void setMn(double value) {
        this.mn = value;
    }

}
