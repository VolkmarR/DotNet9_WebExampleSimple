# Step 2 - Web Api implementation

## Implement the database model

### Add folders and classes for the database model

* Add a new folder DB 
* Add new classes for the database model
  * QuestionsContext.cs
  * Question.cs

### Add properties for the Question class

<details><summary>Add properties to Question class.</summary>
 
~~~c#
[Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int Id { get; set; }
public string Content { get; set; } = "";
public int Votes { get; set; } = 0;
~~~
</details>

### Fix the "Cannot resolve symbol" errors

Use the Context Action "Import missing references in file" to fix the "Cannot resolve symbol" errors. This action adds the missing using statements to the file.

### Implement the QuestionsContext class

<details><summary>Add DbContext as base class ( : DbContext ) for the QuestionsContext class.</summary>

~~~c#
public class QuestionsContext : DbContext
~~~
</details>

<details><summary>Add a constructor with an DbContextOptions options parameter for dependency injection to the class.</summary>

~~~c#
public QuestionsContext(DbContextOptions options) : base(options)
{
}
~~~
</details>

<details><summary>Add DbSet for Questions to the QuestionsContext class.</summary>

~~~c#
public DbSet<Question> Questions { get; set; }
~~~
</details>

### Fix the "Cannot resolve symbol" errors

Use the Context Action "Import missing references in file" to fix the "Cannot resolve symbol" errors. This action adds the missing using statements to the file.

### Configure EntityFramework in program.cs to use SQLite

<details><summary>Add the context to the Services (after the "Add Swagger" block) and configure it to use the SQLite provider(before builder.Build()).</summary>

~~~c#
// Configuration for Entity Framework
var connectionString = new SqliteConnectionStringBuilder() { DataSource = "Production.db" }.ToString();
builder.Services.AddDbContext<QuestionsContext>(x => x.UseSqlite(connectionString));
~~~
</details>

<details><summary>Ensure, that the database exists (after builder.Build()).</summary>

~~~c#
// Make sure, that the database exists
using (var scope = app.Services.CreateScope())
    scope.ServiceProvider.GetRequiredService<QuestionsContext>().Database.EnsureCreated();
~~~
</details>

## Start the project and check for errors

* Start the project and check for errors are shown in the log