using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Product.API.Middleware;
using Product.Core.Entities.Order;
using Product.Core.Services;
using Product.Infrastructure;
using Product.Infrastructure.Repository;
using StackExchange.Redis;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "Authiruaztion",
        Description = "JWt Auth Bearer",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
        }
    };
    s.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
    s.AddSecurityRequirement(securityRequirement);
});
builder.Services.InfraStructureConfigration(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(
        Directory.GetCurrentDirectory(), "wwwroot"
    )));
//Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(i =>
{
    var configure = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
    return ConnectionMultiplexer.Connect(configure);
});
builder.Services.AddScoped<IOrderServices, OrderServices>();
var app = builder.Build();

// ≈‰÷√ HTTP ’à«Ûπ‹µ¿°£
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseCors();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
InfraStructureRequistration.InfrastructureConfigMiddleware(app);
app.Run();
