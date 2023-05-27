
using Business.Entitites;

namespace Infrastructure.Repositories
{
    public interface IBasicRepository
    {
        List<TypeTrip> GetTypeTrips();
        List<Currency> GetCurrencies();
    }
}
