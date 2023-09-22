
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class ConstructorResultsErgastEndpoints
    {
        public static void MapConstructorResultsErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/ConstructorResultsErgast").WithTags(nameof(ConstructorResultsErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.constructorResults.ToListAsync();
            })
            .WithName("GetAllConstructorResultsErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<ConstructorResultsErgast>, NotFound>> (int constructorresultsid, FormulaContext db) =>
            {
                return await db.constructorResults.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.constructorResultsId == constructorresultsid)
                    is ConstructorResultsErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetConstructorResultsErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int constructorresultsid, ConstructorResultsErgast constructorResultsErgast, FormulaContext db) =>
            {
                var affected = await db.constructorResults
                    .Where(model => model.constructorResultsId == constructorresultsid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.constructorResultsId, constructorResultsErgast.constructorResultsId)
                      .SetProperty(m => m.raceId, constructorResultsErgast.raceId)
                      .SetProperty(m => m.constructorId, constructorResultsErgast.constructorId)
                      .SetProperty(m => m.points, constructorResultsErgast.points)
                      .SetProperty(m => m.status, constructorResultsErgast.status)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateConstructorResultsErgast")
            .WithOpenApi();

            group.MapPost("/", async (ConstructorResultsErgast constructorResultsErgast, FormulaContext db) =>
            {
                db.constructorResults.Add(constructorResultsErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/ConstructorResultsErgast/{constructorResultsErgast.constructorResultsId}", constructorResultsErgast);
            })
            .WithName("CreateConstructorResultsErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int constructorresultsid, FormulaContext db) =>
            {
                var affected = await db.constructorResults
                    .Where(model => model.constructorResultsId == constructorresultsid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteConstructorResultsErgast")
            .WithOpenApi();
        }
    }
}