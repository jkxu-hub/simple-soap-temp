using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleSoapTemperature.Models;

[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class Envelope
{
    [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public Body Body { get; set; }
}

public class Body
{
    [XmlElement(ElementName = "FahrenheitToCelsiusResponse", Namespace = "https://www.w3schools.com/xml/")]
    public FahrenheitToCelsiusResponse FahrenheitToCelsiusResponse { get; set; }
}

public class FahrenheitToCelsiusResponse
{
    [XmlElement(ElementName = "FahrenheitToCelsiusResult", Namespace = "https://www.w3schools.com/xml/")]
    public double FahrenheitToCelsiusResult { get; set; }
}