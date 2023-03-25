using APIUsingDapper.OperationFilters;
using Microsoft.OpenApi.Models;
using Mobile_Shop_Management.DAL;
using Mobile_Shop_Management.DAL.Interface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IMobileShop, MobileShopRepo>();
builder.Services.AddSwaggerGen(

    options =>
    {
        options.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Api", Version = "v1" });
        options.AddSecurityDefinition(name: "oauth2", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Flows = new OpenApiOAuthFlows
            {
                ClientCredentials = new OpenApiOAuthFlow
                {
                    TokenUrl = new Uri("https://localhost:7177/connect/tokens"),
                    Scopes = new Dictionary<string, string>
            {
                { "api", "API" }
            }
                }
            }
        });
        options.OperationFilter<AuthorizeOperationFilter>();
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    }

    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
