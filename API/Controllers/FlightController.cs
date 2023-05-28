using API.Extensions;
using BusinessEntities.DTOs;
using Domain.Services;

namespace API.Controllers
{
    public static class FlightController
    {
        public static void FlightRoutes(this WebApplication app)
        {
            app.MapPost("api/flight", async (IFlightService flightService, RequestFlight requestFlight) => Results.Extensions.ResultResponse(await flightService.GetFlightsAsync(requestFlight)));
            app.MapGet("api/flight/{typeTrip}", async (IFlightService flightService, string typeTrip) => await flightService.GetFlights2Async(typeTrip));
        }
    }
}
