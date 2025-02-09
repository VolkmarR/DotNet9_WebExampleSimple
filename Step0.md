# Step 0 - setup the project

## Create the Solution

* Create new, Web project
  * Solution name: QuestionsAppSimple
  * Project name: QuestionsAppSimple
  * Target framework: .NET 9.0
  * Template: Empty
* Save all

## Add nuget packages

* Add the following nuget packages to the project
  * Microsoft.AspNetCore.OpenApi
  * Microsoft.EntityFrameworkCore.Sqlite
  * Microsoft.EntityFrameworkCore.Sqlite.Core
  * Swashbuckle.AspNetCore

## Enable Swagger

* Add the following code to the Program.cs file between the `var builder = WebApplication.CreateBuilder(args);` and `var app = builder.Build();` lines.

~~~c#
// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
~~~

* Add the following code to the Program.cs file before the `app.Run();` lines.

~~~c#
// Enable swagger and SwaggerUI in Developer Mode.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
~~~

## Start the project and test the api

* Start the project
* A browser window should open and navigate to localhost
* The page should display Hello World!
* Add /swagger to the address shown in the browser
* The page should display QuestionsAppSimple
