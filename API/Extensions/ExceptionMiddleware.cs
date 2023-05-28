using BusinessEntities.Response;
using System.Net;
using System.Text.Json;

namespace API.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegatext)
        {
            this._requestDelegate = requestDelegatext;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await GetErrorResult(context, ex, HttpStatusCode.Conflict);
            }
        }

        private async Task GetErrorResult(HttpContext context, Exception exception, HttpStatusCode code)
        {
            string controllerName = context.Request.Path.ToString();
            string action = context.Request.Method.ToString();
            context.Response.Clear();
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = @"application/json";
            var error = CreateErrorResponse(exception, context, controllerName, action);
            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
        private string GetMessageException(Exception exception, string message = "")
        {
            message += string.IsNullOrEmpty(message) ? $"Exception: {exception.Message}" : $"Exception: {exception.Message}.";
            message += exception.InnerException != null ? $"Inner Exception: {exception.InnerException.Message}." : "";
            return message;
        }
        private ErrorResponse CreateErrorResponse(Exception exception, HttpContext context, string controllerName, string actionName)
        {
            return new()
            {
                Message = GetMessageException(exception),
                ControllerName = controllerName,
                ActionName = actionName,
                ErrorCode = context.Response.StatusCode.ToString(),
                LogDate = DateTimeOffset.Now
            };
        }
    }
}
