using API.Extensions;
using BusinessEntities.DTOs;
using Domain.Services;

namespace API.Controllers
{
    public static class FlightController
    {
        public static void FlightRoutes(this WebApplication app)
        {            
            app.MapGet("api/flight/{origin}/{destination}", async (IFlightService flightService, string origin, string destination) 
                => Results.Extensions.ResultResponse(await flightService.GetFlightsAsync(origin, destination)));
        }
    }
}
