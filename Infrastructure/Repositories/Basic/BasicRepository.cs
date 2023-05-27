using Business.Entitites;

namespace Infrastructure.Repositories
{
    public class BasicRepository: IBasicRepository
    {
        public BasicRepository()
        {

        }
        /// <summary>
        /// Obtiene la lista de tipos de Viajes
        /// </summary>
        /// <returns></returns>
        public List<TypeTrip> GetTypeTrips()
        {
            List<TypeTrip> typeTrips = new List<TypeTrip>();
            typeTrips.Add(new TypeTrip {
             Id = 1,
             Description="One Trip",
             Code="0",
             Active = true
            });
            typeTrips.Add(new TypeTrip
            {
                Id = 2,
                Description = "Multiple Trip",
                Code = "1",
                Active = true
            });
            typeTrips.Add(new TypeTrip
            {
                Id = 3,
                Description = "Round Trip",
                Code = "2",
                Active = true
            });

            return typeTrips;
        }
        /// <summary>
        /// Obtiene la lista de tipos de moneda para realizar conversion
        /// </summary>
        /// <returns></returns>
        public List<Currency> GetCurrencies()
        {
            List<Currency> currencies = new List<Currency>();
            currencies.Add(new Currency
            {
                Id = 1,
                Code = "EUR",
                Convertion = 2,
                Active = true
            });
            currencies.Add(new Currency
            {
                Id = 2,                
                Code = "COP",
                Convertion = 4,
                Active = true
            });
            return currencies;
        }
    }
}
