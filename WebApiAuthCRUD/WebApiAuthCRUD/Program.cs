using Microsoft.EntityFrameworkCore;
using WebApiAuthCRUD.BAL.Contracts;
using WebApiAuthCRUD.BAL.Services;
using WebApiAuthCRUD.DAL.Contracts;
using WebApiAuthCRUD.DAL.Repositories;
using Microsoft.Identity.Web;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//connectionString = "";
//var connectionString = builder.Configuration.GetConnectionString("Default") ?? "Host = 172.17.0.3:5432; Database = simple_postgres_instance; Username = postgres; Password = 4Vd59Ab4dt; Pooling = true;";
var connectionString = builder.Configuration.GetConnectionString("OrWSLDockerPostGresConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//?? "Host = localhost:5432; Database = simple_postgres_instance; Username = postgres; Password = Password12345; Pooling = true;";

//builder.Services.AddDbContext<ApplicationContext>(
//    options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));

builder.Services.AddDbContext<ApplicationContext>(opt =>
            opt.UseNpgsql(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IBookService, BookService>();


builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration, "AzureAd")
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDistributedTokenCaches();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
