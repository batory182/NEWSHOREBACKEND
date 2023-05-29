using AutoMapper;
using Business.Entitites;
using BusinessEntities.DTOs;
using Infrastructure.ExternalWebServices;
using System.Collections.Generic;
using System.ComponentModel;

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
        public async Task<Journey> GetFlightsAsync(string origin, string destination)
        {
            Journey journey = new Journey();
            journey.Origin = origin;
            journey.Destination = destination;
            var type = "1";
            var flights = await _consumeRepository.GetFlightsAsync(type);
            var routes = GetRoutes1(origin, destination, flights);
            journey.Flights = routes;
            if (journey.Flights.Count() > 0)
                journey.Price = journey.Flights.Sum(x => x.Price);
            return journey;
        }
        private List<Flight> GetRoutes(string origin, string destination, List<Flight> flights)
        {
            List<Flight> routes = new List<Flight>();
            var origins = flights.Where(x => x.Origin == origin);
            if (origins.Where(x => x.Destination == destination).Count() == 1)
            {
                routes.Add(origins.Where(x => x.Destination == destination).First());
                return routes;
            }

            foreach (var item in origins)
            {
                routes.Add(item);
                var arrives = flights.Where(x => x.Origin == item.Destination);
                foreach (var arrive in arrives)
                {
                    if (arrive.Destination == destination)
                    {
                        routes.Add(arrive);
                    }
                    else
                    {
                        routes.Remove(item);
                    }
                }
            }
            return routes;
        }
        private List<Flight> GetRoutes1(string origin, string destination, List<Flight> flights)
        {
            List<Flight> routes = new List<Flight>();
            var origins = flights.Where(x => x.Origin == origin);
            foreach (var item in origins)
            {
                routes = GetRoute(origin, destination, routes, flights, item);
                if (routes.First().Origin == origin && routes.Last().Destination == destination)
                {
                    return routes;
                }
            }
            return new List<Flight>();
        }
        private List<Flight> GetRoute(string origin, string destination, List<Flight>? routes, List<Flight> flights, Flight lastRoute)
        {
            routes.Add(lastRoute);
            if (routes.First().Origin == origin && routes.Last().Destination == destination)
            {
                return routes;
            }
            else
            {
                var arrives = flights.Where(x => x.Origin == lastRoute.Destination);
                foreach (var arrive in arrives)
                {
                    if (arrive.Destination == destination)
                    {
                        routes = GetRoute(origin, destination, routes, flights, arrive);
                    }
                }
            }
            return routes;
        }
    }
}
