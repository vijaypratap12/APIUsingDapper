using APIUsingDapper.DAL;
using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Libmongocrypt;
using System.Reflection;
using System.Text;

<<<<<<< HEAD
internal class Program
=======
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
>>>>>>> 32919ed7af6a6636877052f8f224f250f7c73d5a
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<IRestaurant, RestaurantRepo>();        

        builder.Services.AddSwaggerGen(
        c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWT Token API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. " +
                        "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                  {
                    new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                             }
                         },
                            new string[] {}
                   }
                });
         });
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

            .AddJwtBearer(
         options =>
         {
             options.RequireHttpsMetadata = false;
             options.SaveToken = true;
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = false,
                 ValidateAudience = false,
                 ValidateIssuerSigningKey = true,
                 ValidIssuer = builder.Configuration["Jwt:Issuser"],
                 ValidAudience = builder.Configuration["Jwt:Audience"],
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
             };
         });

        var app = builder.Build();
       
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        
        // using custom middleware 
        //app.UseMiddleware<CustomMiddleware>();

        app.MapControllers();

        app.Run();
    }
}