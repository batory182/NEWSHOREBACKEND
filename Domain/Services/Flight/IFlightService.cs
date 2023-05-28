using Business.Entitites;
using BusinessEntities.DTOs;

namespace Domain.Services
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync(RequestFlight requestFlight);
        Task<List<ResponseFlight>> GetFlights2Async(string typeTrip);
    }
}
