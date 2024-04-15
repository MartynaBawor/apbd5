using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/animals", () =>
        {
            // 200 - Ok
            // 201 - Created
            // 400 - Bad request
            // 401 - Unauthorized
            // 403 - Forbidden
            // 404 - Not Found

            var animals = StaticData.Animals;
            return Results.Ok(animals);
        });

        app.MapGet("/animals/{id}", ([FromRoute] int id) =>
        {
            var animals = StaticData.Animals;
            return Results.Ok(id);
        });

        app.MapPost("/animals/", (Animal animal) =>
        {
            return Results.Created("", animal);
        });
    }
}