
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class LapTimesErgastEndpoints
    {
        public static void MapLapTimesErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/LapTimesErgast").WithTags(nameof(LapTimesErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.lapTimes.ToListAsync();
            })
            .WithName("GetAllLapTimesErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<LapTimesErgast>, NotFound>> (int raceid, FormulaContext db) =>
            {
                return await db.lapTimes.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.raceId == raceid)
                    is LapTimesErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetLapTimesErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int raceid, LapTimesErgast lapTimesErgast, FormulaContext db) =>
            {
                var affected = await db.lapTimes
                    .Where(model => model.raceId == raceid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.raceId, lapTimesErgast.raceId)
                      .SetProperty(m => m.driverId, lapTimesErgast.driverId)
                      .SetProperty(m => m.lap, lapTimesErgast.lap)
                      .SetProperty(m => m.position, lapTimesErgast.position)
                      .SetProperty(m => m.time, lapTimesErgast.time)
                      .SetProperty(m => m.milliseconds, lapTimesErgast.milliseconds)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateLapTimesErgast")
            .WithOpenApi();

            group.MapPost("/", async (LapTimesErgast lapTimesErgast, FormulaContext db) =>
            {
                db.lapTimes.Add(lapTimesErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/LapTimesErgast/{lapTimesErgast.raceId}", lapTimesErgast);
            })
            .WithName("CreateLapTimesErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int raceid, FormulaContext db) =>
            {
                var affected = await db.lapTimes
                    .Where(model => model.raceId == raceid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteLapTimesErgast")
            .WithOpenApi();
        }
    }
}