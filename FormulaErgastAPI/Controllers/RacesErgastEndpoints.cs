
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class RacesErgastEndpoints
    {
        public static void MapRacesErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/RacesErgast").WithTags(nameof(RacesErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.races.ToListAsync();
            })
            .WithName("GetAllRacesErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<RacesErgast>, NotFound>> (int raceid, FormulaContext db) =>
            {
                return await db.races.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.raceId == raceid)
                    is RacesErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetRacesErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int raceid, RacesErgast racesErgast, FormulaContext db) =>
            {
                var affected = await db.races
                    .Where(model => model.raceId == raceid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.raceId, racesErgast.raceId)
                      .SetProperty(m => m.year, racesErgast.year)
                      .SetProperty(m => m.round, racesErgast.round)
                      .SetProperty(m => m.circuitId, racesErgast.circuitId)
                      .SetProperty(m => m.name, racesErgast.name)
                      .SetProperty(m => m.date, racesErgast.date)
                      .SetProperty(m => m.time, racesErgast.time)
                      .SetProperty(m => m.url, racesErgast.url)
                      .SetProperty(m => m.fp1_date, racesErgast.fp1_date)
                      .SetProperty(m => m.fp1_time, racesErgast.fp1_time)
                      .SetProperty(m => m.fp2_date, racesErgast.fp2_date)
                      .SetProperty(m => m.fp2_time, racesErgast.fp2_time)
                      .SetProperty(m => m.fp3_date, racesErgast.fp3_date)
                      .SetProperty(m => m.fp3_time, racesErgast.fp3_time)
                      .SetProperty(m => m.quali_date, racesErgast.quali_date)
                      .SetProperty(m => m.quali_time, racesErgast.quali_time)
                      .SetProperty(m => m.sprint_date, racesErgast.sprint_date)
                      .SetProperty(m => m.sprint_time, racesErgast.sprint_time)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateRacesErgast")
            .WithOpenApi();

            group.MapPost("/", async (RacesErgast racesErgast, FormulaContext db) =>
            {
                db.races.Add(racesErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/RacesErgast/{racesErgast.raceId}", racesErgast);
            })
            .WithName("CreateRacesErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int raceid, FormulaContext db) =>
            {
                var affected = await db.races
                    .Where(model => model.raceId == raceid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteRacesErgast")
            .WithOpenApi();
        }
    }
}