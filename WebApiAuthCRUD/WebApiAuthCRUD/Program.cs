using Microsoft.EntityFrameworkCore;
using WebApiAuthCRUD.BAL.Contracts;
using WebApiAuthCRUD.BAL.Services;
using WebApiAuthCRUD.DAL.Contracts;
using WebApiAuthCRUD.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationContext>(
    options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddMicrosoftIdentityWebApiAuthentication(
    builder.Configuration, "AzureAd");

//builder.Services.AddMicrosoftIdentityWebApiAuthentication(
//   builder.Configuration, "AzureAd");

//services.AddMicrosoftIdentityWebApiAuthentication(Configuration)
//                    .EnableTokenAcquisitionToCallDownstreamApi()
//                        .AddMicrosoftGraph(Configuration.GetSection("DownstreamApi"))
//                        .AddInMemoryTokenCaches();



builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseAuthentication();

app.MapControllers();

app.Run();
