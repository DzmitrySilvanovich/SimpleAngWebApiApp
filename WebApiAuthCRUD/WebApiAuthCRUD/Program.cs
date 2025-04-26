using Microsoft.EntityFrameworkCore;
using WebApiAuthCRUD.BAL.Contracts;
using WebApiAuthCRUD.BAL.Services;
using WebApiAuthCRUD.DAL.Contracts;
using WebApiAuthCRUD.DAL.Repositories;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationContext>(
    options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));

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
