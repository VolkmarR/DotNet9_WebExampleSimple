using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using QuestionsAppSimple.DB;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration for Entity Framework
var connectionString = new SqliteConnectionStringBuilder() { DataSource = "Production.db" }.ToString();
builder.Services.AddDbContext<QuestionsContext>(x => x.UseSqlite(connectionString));

var app = builder.Build();

// Make sure, that the database exists
using (var scope = app.Services.CreateScope())
    scope.ServiceProvider.GetRequiredService<QuestionsContext>().Database.EnsureCreated();

app.MapGet("/", () => "Hello World!");

// Enable swagger and SwaggerUI in Developer Mode.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();