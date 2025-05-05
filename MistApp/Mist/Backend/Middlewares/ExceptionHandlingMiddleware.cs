using System.Net;
using System.Security.Authentication;
using System.Text.Json;

namespace Mist.Backend.Middlewares
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context); // pass the request to the next middleware
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			HttpStatusCode statusCode;

			switch (exception)
			{
				case KeyNotFoundException:
					statusCode = HttpStatusCode.NotFound;
					break;
				case UnauthorizedAccessException:
					statusCode = HttpStatusCode.Forbidden;
					break;
				case AuthenticationException:
					statusCode = HttpStatusCode.Unauthorized;
					break;
				default:
					statusCode = HttpStatusCode.InternalServerError; // default is 500
					break;
			}

			var result = JsonSerializer.Serialize(new
			{
				error = exception.Message
			});

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)statusCode;

			return context.Response.WriteAsync(result);
		}
	}
}