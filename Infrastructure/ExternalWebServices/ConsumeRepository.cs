using Business.Entitites;
using Business.Entitites.Settings;
using BusinessEntities.DTOs;
using System.Text.Json;

namespace Infrastructure.ExternalWebServices
{
    public class ConsumeRepository: IConsumeRepository
    {
        private readonly HttpClient _apiClient;
        private readonly GlobalAppSettings _globalAppSettings;
        private readonly string urlService;

        public ConsumeRepository(GlobalAppSettings globalAppSettings)
        {
            _globalAppSettings = globalAppSettings;
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            _apiClient = new HttpClient(httpClientHandler);            
            urlService = _globalAppSettings.Settings.UrlService;
        }
        public async Task<IEnumerable<ResponseFlight>> GetFlightsAsync(string typeTrip)
        {      
            IEnumerable<ResponseFlight> flights;
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(urlService + "/" + typeTrip);
                //var result = "[\r\n    {\r\n        \"departureStation\": \"MZL\",\r\n        \"arrivalStation\": \"MDE\",\r\n        \"flightCarrier\": \"CO\",\r\n        \"flightNumber\": \"8001\",\r\n        \"price\": 200\r\n    },\r\n    {\r\n        \"departureStation\": \"MZL\",\r\n        \"arrivalStation\": \"CTG\",\r\n        \"flightCarrier\": \"CO\",\r\n        \"flightNumber\": \"8002\",\r\n        \"price\": 200\r\n    },\r\n    {\r\n        \"departureStation\": \"PEI\",\r\n        \"arrivalStation\": \"BOG\",\r\n        \"flightCarrier\": \"CO\",\r\n        \"flightNumber\": \"8003\",\r\n        \"price\": 200\r\n    },\r\n    {\r\n        \"departureStation\": \"MDE\",\r\n        \"arrivalStation\": \"BCN\",\r\n        \"flightCarrier\": \"CO\",\r\n        \"flightNumber\": \"8004\",\r\n        \"price\": 500\r\n    },\r\n    {\r\n        \"departureStation\": \"CTG\",\r\n        \"arrivalStation\": \"CAN\",\r\n        \"flightCarrier\": \"CO\",\r\n        \"flightNumber\": \"8005\",\r\n        \"price\": 300\r\n    },\r\n    {\r\n        \"departureStation\": \"BOG\",\r\n        \"arrivalStation\": \"MAD\",\r\n        \"flightCarrier\": \"CO\",\r\n        \"flightNumber\": \"8006\",\r\n        \"price\": 500\r\n    },\r\n    {\r\n        \"departureStation\": \"BOG\",\r\n        \"arrivalStation\": \"MEX\",\r\n        \"flightCarrier\": \"CO\",\r\n        \"flightNumber\": \"8007\",\r\n        \"price\": 300\r\n    }\r\n]";                
                flights = JsonSerializer.Deserialize<IEnumerable<ResponseFlight>>(result);
            }            
            return flights;
        }
    }
}
