using BaseRestApi.Data;
using BaseRestApi.Data.Interface;
using BaseRestApi.Lib;
using BaseRestApi.Lib.Interface;
using BaseRestApi.Services;
using BaseRestApi.Services.Interface;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// from Sartup
builder.Services.AddDbContext<BaseRestApiContext>(db =>
{
    string connectionString = builder.Configuration.GetConnectionString("baseApiConnection");
    db.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var appSettings = new AppSettings();
builder.Configuration.GetSection("AppSettings").Bind(appSettings);
builder.Services.AddTransient<AppSettings>(x => { return appSettings; });

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ITrace, Trace>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<IPointOfPurchaseRepository, PointOfPurchaseRepository>();
builder.Services.AddTransient<IPointOfPurchaseService, PointOfPurchaseService>();

var jwtKey = Encoding.ASCII.GetBytes(appSettings.Jwt.Secret);
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => 
{
    options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            return Task.CompletedTask;
        }
    };
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(jwtKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();
app.UseCors(x => x 
    .AllowAnyOrigin() 
    .AllowAnyMethod() 
    .AllowAnyHeader()
);


app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
