using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace API.Extensions
{
    internal static class ResultExtension
    {
        internal static IResult ResultResponse<T>(this IResultExtensions resultExtensions, T data, string message = null, bool success = true)
        {
            ArgumentNullException.ThrowIfNull(resultExtensions, nameof(resultExtensions));
            return new Result<T>(data, message, success);
        }
        class Result<T> : IResult
        {
            public Result(T data, string message = null, bool success = true)
            {
                this.Data = data;
                this.Message = message;
                this.Success = success;
            }

            public T Data { get; private set; }
            public string Message { get; private set; }
            public bool Success { get; private set; }

            public Task ExecuteAsync(HttpContext httpContext) 
            {
                string content = JsonSerializer.Serialize(this);
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(content);
                switch (httpContext.Request.Method)
                {
                    case "GET":
                        httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                        break;
                    case "POST":
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Created;
                        break;
                    default:
                        break;
                }

                return httpContext.Response.WriteAsync(content);
            }
        }
    }
}
