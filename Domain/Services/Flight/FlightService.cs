using AutoMapper;
using Business.Entitites;
using BusinessEntities.DTOs;
using Infrastructure.ExternalWebServices;

namespace Domain.Services
{
    public class FlightService : IFlightService
    {
        public readonly IConsumeRepository _consumeRepository;
        public readonly IMapper _mapper;
        public FlightService(IConsumeRepository consumeRepository, IMapper mapper)
        {
            _consumeRepository = consumeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Flight>> GetFlightsAsync(RequestFlight requestFlight)
        {
            var result = await _consumeRepository.GetFlightsAsync(requestFlight.TypeTrip);
            var x = _mapper.Map<IEnumerable<Flight>>(result);
            return x;
        }
        public async Task<List<ResponseFlight>> GetFlights2Async(string typeTrip)
        { 
            var x = await _consumeRepository.GetFlightsAsync(typeTrip);
            return x.ToList();
        }
    }
}
