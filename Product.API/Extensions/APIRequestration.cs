using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Product.API.Errors;
using System.Reflection;

namespace Product.API.Extensions
{
    public static class APIRequestration
    {
        /// <summary>
        /// 註冊 API 服務，包括 AutoMapper、檔案提供者、模型驗證錯誤回應處理，以及 CORS 支援配置。
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiReguestration(this IServiceCollection services)
        {

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //FileProvide
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot"
                )));


            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = context.ModelState
                                .Where(x => x.Value.Errors.Count > 0)
                                .SelectMany(x => x.Value.Errors)
                                .Select(x => x.ErrorMessage).ToArray()
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            //Enable CORS
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", pol =>
                {
                    pol.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:4200");
                });
            });
            return services;
        }
    }
}
