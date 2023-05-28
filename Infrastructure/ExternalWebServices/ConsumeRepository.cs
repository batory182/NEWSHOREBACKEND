using AutoMapper;
using Business.Entitites;
using Business.Entitites.Settings;
using BusinessEntities.DTOs;
using System.Text.Json;

namespace Infrastructure.ExternalWebServices
{
    public class ConsumeRepository : IConsumeRepository
    {
        private readonly HttpClient _apiClient;
        private readonly GlobalAppSettings _globalAppSettings;
        private readonly string urlService;
        private readonly IMapper _mapper;

        public ConsumeRepository(GlobalAppSettings globalAppSettings, IMapper mapper)
        {
            _globalAppSettings = globalAppSettings;
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            _apiClient = new HttpClient(httpClientHandler);
            urlService = _globalAppSettings.Settings.UrlService;
            _mapper = mapper;
        }
        public async Task<List<Flight>> GetFlightsAsync(string typeTrip)
        {
            var result = await _apiClient.GetStringAsync(urlService + "/" + typeTrip);
            return _mapper.Map<List<Flight>>(JsonSerializer.Deserialize<IEnumerable<ResponseFlight>>(result));
        }
    }
}
