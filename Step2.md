# Implement the Minimal API Routes

## Remove Minimal API example in Program.cs

<details><summary>Remove the example api map.</summary>

~~~c#
app.MapGet("/", () => "Hello World!");
~~~
</details>

## Add a get route to get all questions

<details><summary>Add a get route to get all questions.</summary>

~~~c#
// API Routes

app.MapGet("api/questions", async (QuestionsContext context)
    => await context.Questions.ToListAsync());
~~~
</details>

## Add a post route to add a new question

<details><summary>Add a post route to add a new question.</summary>

~~~c#
app.MapPost("api/questions/", async (QuestionsContext context, string content) =>
{
    if (string.IsNullOrWhiteSpace(content))
        return Results.BadRequest("The Question Content can not be empty");

    context.Questions.Add(new Question { Content = content });
    await context.SaveChangesAsync();
    return Results.Ok();
});
~~~
</details>

## Add a post route to vote for a question

<details><summary>Add a post route to vote for a question.</summary>

~~~c#
app.MapPost("api/questions/{id:int}/vote", async (QuestionsContext context, int id) =>
{
    var question = await context.Questions.FirstOrDefaultAsync(q => q.Id == id);
    if (question is null)
        return Results.BadRequest("Invalid Question Id");

    question.Votes++;
    await context.SaveChangesAsync();
    return Results.Ok();
});
~~~
</details>

## Start the project and test the api useing the swagger ui

* Start the project
* A browser window should open and navigate to localhost but display a message that the page was not found
* Add /swagger to the address shown in the browser
* The page should display QuestionsAppSimple with the 3 api routes
