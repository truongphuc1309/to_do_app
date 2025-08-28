using Microsoft.AspNetCore.Diagnostics;
using TodoApi.Dto;

namespace TodoApi.Exception;

 public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken = default)
        {
            var responseError = new ApiResponse<object>
            {
                Success = false,
                Message = exception.Message,
                Error = exception.GetType().ToString()
            };
            await httpContext.Response.WriteAsJsonAsync(responseError, cancellationToken);
            return true;
        }
    }
