using System.Text.Json;
using System.Text.Json.Serialization;

namespace BusinessEntities.DTOs
{
    public class ResponseFlight
    {
        [JsonPropertyName("departureStation")]
        public string DepartureStation { get; set; }
        [JsonPropertyName("arrivalStation")]
        public string ArrivalStation { get; set; }
        [JsonPropertyName("flightCarrier")]
        public string FlightCarrier { get; set; }
        [JsonPropertyName("flightNumber")]
        public string FlightNumber { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
