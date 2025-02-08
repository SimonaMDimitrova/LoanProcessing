using LoanProccessing.Data;
using LoanProccessing.Data.Seeding;
using LoanProccessing.Data.Repositories;
using LoanProccessing.Services;

using System.Data;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlLiteConnectionString");

builder.Services.AddSingleton<IDbConnection>(sp =>
{
    var connection = new SqliteConnection(connectionString);
    connection.Open();

    return connection;
});

builder.Services.AddSingleton<LoanProcessingDatabaseInitializer>();

// Add repositories to the container

builder.Services.AddTransient<ILoanRepository, LoanRepository>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();

// Add services to the container

builder.Services.AddTransient<ILoanService, LoanService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();

builder.Services.AddControllers();

// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed data
using (var serviceScope = app.Services.CreateScope())
{
    SQLitePCL.Batteries.Init();

    var dbContext = serviceScope.ServiceProvider.GetRequiredService<LoanProcessingDatabaseInitializer>();
    dbContext.CreateDatabaseAsync().GetAwaiter().GetResult();

    var connection = serviceScope.ServiceProvider.GetRequiredService<IDbConnection>();
    new LoanProcessingDatabaseSeeder().SeedAsync(connection).GetAwaiter().GetResult();
}

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
