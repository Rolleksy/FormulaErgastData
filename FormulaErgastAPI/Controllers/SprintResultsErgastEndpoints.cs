
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class SprintResultsErgastEndpoints
    {
        public static void MapSprintResultsErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/SprintResultsErgast").WithTags(nameof(SprintResultsErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.sprintResults.ToListAsync();
            })
            .WithName("GetAllSprintResultsErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<SprintResultsErgast>, NotFound>> (int resultid, FormulaContext db) =>
            {
                return await db.sprintResults.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.resultId == resultid)
                    is SprintResultsErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetSprintResultsErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int resultid, SprintResultsErgast sprintResultsErgast, FormulaContext db) =>
            {
                var affected = await db.sprintResults
                    .Where(model => model.resultId == resultid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.resultId, sprintResultsErgast.resultId)
                      .SetProperty(m => m.raceId, sprintResultsErgast.raceId)
                      .SetProperty(m => m.driverId, sprintResultsErgast.driverId)
                      .SetProperty(m => m.constructorId, sprintResultsErgast.constructorId)
                      .SetProperty(m => m.number, sprintResultsErgast.number)
                      .SetProperty(m => m.grid, sprintResultsErgast.grid)
                      .SetProperty(m => m.position, sprintResultsErgast.position)
                      .SetProperty(m => m.positionText, sprintResultsErgast.positionText)
                      .SetProperty(m => m.positionOrder, sprintResultsErgast.positionOrder)
                      .SetProperty(m => m.points, sprintResultsErgast.points)
                      .SetProperty(m => m.laps, sprintResultsErgast.laps)
                      .SetProperty(m => m.time, sprintResultsErgast.time)
                      .SetProperty(m => m.milliseconds, sprintResultsErgast.milliseconds)
                      .SetProperty(m => m.fastestLap, sprintResultsErgast.fastestLap)
                      .SetProperty(m => m.fastestLapTime, sprintResultsErgast.fastestLapTime)
                      .SetProperty(m => m.statusId, sprintResultsErgast.statusId)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateSprintResultsErgast")
            .WithOpenApi();

            group.MapPost("/", async (SprintResultsErgast sprintResultsErgast, FormulaContext db) =>
            {
                db.sprintResults.Add(sprintResultsErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/SprintResultsErgast/{sprintResultsErgast.resultId}", sprintResultsErgast);
            })
            .WithName("CreateSprintResultsErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int resultid, FormulaContext db) =>
            {
                var affected = await db.sprintResults
                    .Where(model => model.resultId == resultid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteSprintResultsErgast")
            .WithOpenApi();
        }
    }
}