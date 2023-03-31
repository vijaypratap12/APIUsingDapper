using APIUsingDapper.DAL;
using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddScoped<IUserProfile, UserProfileRepo>();
builder.Services.AddScoped<IRestaurant, RestaurantRepo>();
builder.Services.AddSwaggerGen(
    options =>
builder.Services.AddScoped<IUserProfile, UserProfileRepo>();
//builder.Services.AddSingleton<IUserProfile, UserProfileRepo>();
//builder.Services.AddTransient<IUserProfile, UserProfileRepo>(); 


builder.Services.AddScoped<IEmployee,  EmployeeRepo>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Api", Version = "v1" });
    options.AddSecurityDefinition(name: "oauth2", new OpenApiSecurityScheme
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
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

    });
    options.OperationFilter<AuthorizeOperationFilter>();
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});


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
