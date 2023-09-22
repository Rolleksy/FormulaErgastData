
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class PitStopsErgastEndpoints
    {
        public static void MapPitStopsErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/PitStopsErgast").WithTags(nameof(PitStopsErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.pitStops.ToListAsync();
            })
            .WithName("GetAllPitStopsErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<PitStopsErgast>, NotFound>> (int raceid, FormulaContext db) =>
            {
                return await db.pitStops.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.raceId == raceid)
                    is PitStopsErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetPitStopsErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int raceid, PitStopsErgast pitStopsErgast, FormulaContext db) =>
            {
                var affected = await db.pitStops
                    .Where(model => model.raceId == raceid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.raceId, pitStopsErgast.raceId)
                      .SetProperty(m => m.driverId, pitStopsErgast.driverId)
                      .SetProperty(m => m.stop, pitStopsErgast.stop)
                      .SetProperty(m => m.lap, pitStopsErgast.lap)
                      .SetProperty(m => m.time, pitStopsErgast.time)
                      .SetProperty(m => m.duration, pitStopsErgast.duration)
                      .SetProperty(m => m.milliseconds, pitStopsErgast.milliseconds)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdatePitStopsErgast")
            .WithOpenApi();

            group.MapPost("/", async (PitStopsErgast pitStopsErgast, FormulaContext db) =>
            {
                db.pitStops.Add(pitStopsErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/PitStopsErgast/{pitStopsErgast.raceId}", pitStopsErgast);
            })
            .WithName("CreatePitStopsErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int raceid, FormulaContext db) =>
            {
                var affected = await db.pitStops
                    .Where(model => model.raceId == raceid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeletePitStopsErgast")
            .WithOpenApi();
        }
    }
}