using Business.Entitites;

namespace Domain.Services
{
    public interface IBasicService
    {
        List<Currency> GetCurrencies();
        List<TypeTrip> GetTypeTrips();
    }
}
