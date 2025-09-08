using LokusAPI.Database;
using LokusAPI.Models;
using LokusAPI.Services.AuthServices;
using LokusAPI.Services.ClientServices;
using LokusAPI.Services.ImageServices;
using LokusAPI.Services.SignalRService;
using LokusAPI.Services;
using LokusAPI.Services.CompanyService;
using LokusAPI.Services.StablishmentImage;
using LokusAPI.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var AllowSites = "_AllowSites";

//Adicionando Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSites, policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

//Jwt Autenticao
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
           Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chatHub"))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
}); 


builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CustomerPolicy", Policy => Policy.RequireRole("customer"));
    options.AddPolicy("CompanyPolicy", Policy => Policy.RequireRole("company"));
    options.AddPolicy("Admin", Policy => Policy.RequireRole("admin"));
});

//Aicionando Services *
builder.Services.AddSignalR();
builder.Services.AddScoped<AppDb>();
builder.Services.AddScoped<CustomerImageService>(); 
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>(); 
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<SubscriptionService>();
builder.Services.AddScoped<SpaceService>();
builder.Services.AddScoped<FeedbackService>();
builder.Services.AddScoped<StablishmentService>();
builder.Services.AddScoped<IStablishmentGalleryService, StablishmentGalleryService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<AvailabilityService>();
builder.Services.AddScoped<PaymentService>();



//Conex�o com o Banco de Dados
var connection = builder.Configuration.GetConnectionString("connection");
builder.Services.AddDbContext<AppDb>(options =>
{
    options.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.MaxDepth = 64;
    });
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowSites);

app.UseAuthentication();

app.UseHttpsRedirection();

app.MapHub<ChatHub>("/chatHub");
app.UseAuthorization();

app.MapControllers();

app.Run();
