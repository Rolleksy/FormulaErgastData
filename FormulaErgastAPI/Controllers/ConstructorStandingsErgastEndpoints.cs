
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class ConstructorStandingsErgastEndpoints
    {
        public static void MapConstructorStandingsErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/ConstructorStandingsErgast").WithTags(nameof(ConstructorStandingsErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.constructorStandings.ToListAsync();
            })
            .WithName("GetAllConstructorStandingsErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<ConstructorStandingsErgast>, NotFound>> (int constructorstandingsid, FormulaContext db) =>
            {
                return await db.constructorStandings.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.constructorStandingsId == constructorstandingsid)
                    is ConstructorStandingsErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetConstructorStandingsErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int constructorstandingsid, ConstructorStandingsErgast constructorStandingsErgast, FormulaContext db) =>
            {
                var affected = await db.constructorStandings
                    .Where(model => model.constructorStandingsId == constructorstandingsid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.constructorStandingsId, constructorStandingsErgast.constructorStandingsId)
                      .SetProperty(m => m.raceId, constructorStandingsErgast.raceId)
                      .SetProperty(m => m.constructorId, constructorStandingsErgast.constructorId)
                      .SetProperty(m => m.points, constructorStandingsErgast.points)
                      .SetProperty(m => m.position, constructorStandingsErgast.position)
                      .SetProperty(m => m.positionText, constructorStandingsErgast.positionText)
                      .SetProperty(m => m.wins, constructorStandingsErgast.wins)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateConstructorStandingsErgast")
            .WithOpenApi();

            group.MapPost("/", async (ConstructorStandingsErgast constructorStandingsErgast, FormulaContext db) =>
            {
                db.constructorStandings.Add(constructorStandingsErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/ConstructorStandingsErgast/{constructorStandingsErgast.constructorStandingsId}", constructorStandingsErgast);
            })
            .WithName("CreateConstructorStandingsErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int constructorstandingsid, FormulaContext db) =>
            {
                var affected = await db.constructorStandings
                    .Where(model => model.constructorStandingsId == constructorstandingsid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteConstructorStandingsErgast")
            .WithOpenApi();
        }
    }
}