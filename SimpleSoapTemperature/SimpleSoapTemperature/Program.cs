using System.Xml.Serialization;
using SimpleSoapTemperature.Models;

var soapEndpoint = "https://www.w3schools.com/xml/tempconvert.asmx";
var temperatureInFarenheit = "87";

var soapEnvelope = $@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                          <soap:Body>
                            <FahrenheitToCelsius xmlns=""https://www.w3schools.com/xml/"">
                              <Fahrenheit>{temperatureInFarenheit}</Fahrenheit>
                            </FahrenheitToCelsius>
                          </soap:Body>
                        </soap:Envelope>";

try
{
    // Step 1:  Call the SOAP Endpoint:
    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, soapEndpoint);
    var content = new StringContent(soapEnvelope, null, "text/xml");
    request.Content = content;
    var response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    var soapApiResp = await response.Content.ReadAsStringAsync();
    Console.WriteLine("\n##############################\n");
    Console.WriteLine(soapApiResp);

    // Step 2: Deserialize the response:
    Envelope envelope = null;
    var serializer = new XmlSerializer(typeof(Envelope));
    using (var reader = new StringReader(soapApiResp))
    {
        envelope = (Envelope)serializer.Deserialize(reader);
    }
    Console.WriteLine("\n##############################\n");
    Console.WriteLine($"{temperatureInFarenheit} Farenheit is {envelope?.Body?.FahrenheitToCelsiusResponse?.FahrenheitToCelsiusResult} Celsius");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}