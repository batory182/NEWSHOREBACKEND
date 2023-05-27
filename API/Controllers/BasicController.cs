using API.Extensions;
using Domain.Services.Basic;

namespace API.Controllers
{
    public static class BasicController
    {
        public static void BasicRoutes(this WebApplication app)
        {
            app.MapGet("api/currencies",  (IBasicService basicService) => Results.Extensions.ResultResponse(basicService.GetCurrencies()));
            app.MapGet("api/typeTrips",  (IBasicService basicService) => Results.Extensions.ResultResponse(basicService.GetTypeTrips()));
        }
    }
}
