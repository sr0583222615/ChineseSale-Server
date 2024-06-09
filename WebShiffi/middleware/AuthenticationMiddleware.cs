using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using webApi.models;
using System.Net.Http;
public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuthenticationMiddleware> _logger;

    public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
    {
        _next = next;
        _logger = logger;

    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var identity = context.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var userClaims = identity.Claims;
            var user = new User
            {
                UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                UserPhone = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.HomePhone)?.Value,
                UserEmail = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                UserId = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.UserData)?.Value,

            };

            context.Items["User"] = user;
            await _next(context);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the middleware.");

        }
    }
















}
//namespace AngularServer1.Middleware
//{
//    public class AuthenticationMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<AuthenticationMiddleware> _logger;

//        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
//        {
//            _next = next;
//            _logger = logger;

//        }


//        public async Task InvokeAsync(HttpContext context)
//        {
//            try
//            {
//                var identity = context.User.Identity as ClaimsIdentity;
//                if (identity == null)
//                {
//                    context.Response.StatusCode = 401;
//                    await context.Response.WriteAsync("Unauthorized");
//                    return;
//                }

//                var userClaims = identity.Claims;
//                var user = new User
//                {
//                   UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
//                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
//                    UserPhone = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.HomePhone)?.Value,
//                    UserEmail = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
//                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
//                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
 

//            };

//                var middlewareUser = context.Items["User"] as User;
//                context.Items["User"] = user;

//                await _next(context);

//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "An error occurred in the middleware.");

//            }
//        }

//    }
//    //foreach (var claim in identity.Claims)
//    //{
//    //    _logger.LogInformation($"{claim.Type}: {claim.Value}");
//    //}
//    //public static class MiddlewareExtensions
//    //{
//    //    public static IApplicationBuilder usemidd(this IApplicationBuilder builder)
//    //    {
//    //        return builder.UseMiddleware<Middleware>();
//    //    }
//    //}
//}
///*    context.Items.Add("User", user)*/