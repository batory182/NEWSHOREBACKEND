
using Business.Entitites;
using Infrastructure.Repositories;

namespace Domain.Services
{
    public class BasicService: IBasicService
    {
        public readonly IBasicRepository _basicRepository;
        public BasicService(IBasicRepository basicRepository) => _basicRepository = basicRepository;

        public List<Currency> GetCurrencies() => _basicRepository.GetCurrencies();
        public List<TypeTrip> GetTypeTrips() => _basicRepository.GetTypeTrips();

    }
}
