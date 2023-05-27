using Business.Entitites;

namespace Domain.Services.Basic
{
    public interface IBasicService
    {
        List<Currency> GetCurrencies();
        List<TypeTrip> GetTypeTrips();
    }
}
