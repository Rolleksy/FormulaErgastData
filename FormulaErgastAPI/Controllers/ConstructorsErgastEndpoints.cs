
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class ConstructorsErgastEndpoints
    {
        public static void MapConstructorsErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/ConstructorsErgast").WithTags(nameof(ConstructorsErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.constructors.ToListAsync();
            })
            .WithName("GetAllConstructorsErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<ConstructorsErgast>, NotFound>> (int constructorid, FormulaContext db) =>
            {
                return await db.constructors.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.constructorId == constructorid)
                    is ConstructorsErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetConstructorsErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int constructorid, ConstructorsErgast constructorsErgast, FormulaContext db) =>
            {
                var affected = await db.constructors
                    .Where(model => model.constructorId == constructorid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.constructorId, constructorsErgast.constructorId)
                      .SetProperty(m => m.constructorRef, constructorsErgast.constructorRef)
                      .SetProperty(m => m.name, constructorsErgast.name)
                      .SetProperty(m => m.nationality, constructorsErgast.nationality)
                      .SetProperty(m => m.url, constructorsErgast.url)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateConstructorsErgast")
            .WithOpenApi();

            group.MapPost("/", async (ConstructorsErgast constructorsErgast, FormulaContext db) =>
            {
                db.constructors.Add(constructorsErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/ConstructorsErgast/{constructorsErgast.constructorId}", constructorsErgast);
            })
            .WithName("CreateConstructorsErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int constructorid, FormulaContext db) =>
            {
                var affected = await db.constructors
                    .Where(model => model.constructorId == constructorid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteConstructorsErgast")
            .WithOpenApi();
        }
    }
}