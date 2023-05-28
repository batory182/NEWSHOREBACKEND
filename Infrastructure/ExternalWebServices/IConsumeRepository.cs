using Business.Entitites;
using BusinessEntities.DTOs;

namespace Infrastructure.ExternalWebServices
{
    public interface IConsumeRepository
    {
        Task<IEnumerable<ResponseFlight>> GetFlightsAsync(string typeTrip);
    }
}
