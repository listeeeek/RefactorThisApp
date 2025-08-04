using Microsoft.AspNetCore.Mvc;
using RefactorThisApp;
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ConvertToLambdaExpression

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/aktywneZwierzeta", () =>
    {
        var api = new AnimalRepository();

        var zwierzeta = api.GetAnimals(true);
        
        return zwierzeta;
    })
    .WithName("aktywneZwierzeta")
    .WithOpenApi();

app.MapGet("/niezaszczepione", () =>
    {
        var api = new AnimalRepository();

        var zwierzeta1 = api.GetAnimals(true);
        var zwierzeta2 = api.GetAnimals(false);
        
        var result = new List<Animal>();

        //TODO: tu cos nie dziala ;-(
        foreach (var animal in zwierzeta1)
        {
            if(animal.ListaSzczepien.Count <= 0) result.Add(animal);
        }
        
        foreach (var animal in zwierzeta2)
        {
            if(animal.ListaSzczepien.Count <= 0) result.Add(animal);
        }
        
        return result;
    })
    .WithName("niezaszczepione")
    .WithOpenApi();

app.MapGet("/zwierze", (string nazwa) =>
    {
        var api = new AnimalRepository();

        var rsl = api.GetAnimal(nazwa);
        
        return rsl.Match<IResult>(
            Some: z =>
            {
                return Results.Ok(z);
            },
            None: () =>
            {
                // TODO: tu by sie przydalo logowanie na tym poziomie,
                // LoggerService.Log(msg);
                
                return Results.BadRequest(new {});
            });
    })
    .WithName("zwierze")
    .WithOpenApi();

app.Run();

