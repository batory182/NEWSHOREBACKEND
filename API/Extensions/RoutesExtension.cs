using API.Controllers;
using System.Runtime.CompilerServices;

namespace API.Extensions
{
    internal static class RoutesExtension
    {
        internal static void Routes(this WebApplication app)
        {
            if(app == null)
                throw new ArgumentNullException(nameof(app));
            app.BasicRoutes();
        }
    }
}
