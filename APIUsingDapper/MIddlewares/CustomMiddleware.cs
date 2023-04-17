//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using System.Threading.Tasks;


//namespace MIddlewareExample
//{
//    public class CustomMiddleware 
//    {
//        private readonly RequestDelegate _next;
        
//        public CustomMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }
//        public async Task InvokeAsync(HttpContext httpContext)
//        {
//               await httpContext.Response.WriteAsync("hello world 1");
//        }
//    }
//        public static class CustomMiddlewareExtensions 
//        {
//            public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
//            {
//                return builder.UseMiddleware<CustomMiddleware>();
//            }
//        }
//}


   
    
