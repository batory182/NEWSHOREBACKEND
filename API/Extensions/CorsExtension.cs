namespace API.Extensions
{
    internal static class CorsExtension
    {
        internal static void AddCorsDoc(this IServiceCollection services, string allowedOrigins) => services.AddCors(
             options =>
             {
                 options.AddPolicy("NewShorePolicy",
                     policy =>
                     {
                         policy.WithOrigins(allowedOrigins.Split(";"))
                         .AllowAnyHeader()
                         .AllowAnyHeader();
                     });
             });
        internal static void UserCorsDoc(this IApplicationBuilder app) => app.UseCors("NewShorePolicy");
    }
}
