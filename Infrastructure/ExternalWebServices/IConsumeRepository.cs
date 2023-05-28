using Business.Entitites;
using BusinessEntities.DTOs;

namespace Infrastructure.ExternalWebServices
{
    public interface IConsumeRepository
    {
        Task<List<Flight>> GetFlightsAsync(string typeTrip);
    }
}
