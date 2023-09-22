
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class ResultsErgastEndpoints
    {
        public static void MapResultsErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/ResultsErgast").WithTags(nameof(ResultsErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.results.ToListAsync();
            })
            .WithName("GetAllResultsErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<ResultsErgast>, NotFound>> (int resultid, FormulaContext db) =>
            {
                return await db.results.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.resultId == resultid)
                    is ResultsErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetResultsErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int resultid, ResultsErgast resultsErgast, FormulaContext db) =>
            {
                var affected = await db.results
                    .Where(model => model.resultId == resultid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.resultId, resultsErgast.resultId)
                      .SetProperty(m => m.raceId, resultsErgast.raceId)
                      .SetProperty(m => m.driverId, resultsErgast.driverId)
                      .SetProperty(m => m.constructorId, resultsErgast.constructorId)
                      .SetProperty(m => m.number, resultsErgast.number)
                      .SetProperty(m => m.grid, resultsErgast.grid)
                      .SetProperty(m => m.position, resultsErgast.position)
                      .SetProperty(m => m.positionText, resultsErgast.positionText)
                      .SetProperty(m => m.positionOrder, resultsErgast.positionOrder)
                      .SetProperty(m => m.points, resultsErgast.points)
                      .SetProperty(m => m.laps, resultsErgast.laps)
                      .SetProperty(m => m.time, resultsErgast.time)
                      .SetProperty(m => m.milliseconds, resultsErgast.milliseconds)
                      .SetProperty(m => m.fastestLap, resultsErgast.fastestLap)
                      .SetProperty(m => m.rank, resultsErgast.rank)
                      .SetProperty(m => m.fastestLapTime, resultsErgast.fastestLapTime)
                      .SetProperty(m => m.fastestLapSpeed, resultsErgast.fastestLapSpeed)
                      .SetProperty(m => m.statusId, resultsErgast.statusId)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateResultsErgast")
            .WithOpenApi();

            group.MapPost("/", async (ResultsErgast resultsErgast, FormulaContext db) =>
            {
                db.results.Add(resultsErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/ResultsErgast/{resultsErgast.resultId}", resultsErgast);
            })
            .WithName("CreateResultsErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int resultid, FormulaContext db) =>
            {
                var affected = await db.results
                    .Where(model => model.resultId == resultid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteResultsErgast")
            .WithOpenApi();
        }
    }
}