using Business.Entitites;
using BusinessEntities.DTOs;

namespace Domain.Services
{
    public interface IFlightService
    {
        Task<Journey> GetFlightsAsync(string origin, string destination);
    }
}
