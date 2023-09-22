
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class DriverStandingsErgastEndpoints
    {
        public static void MapDriverStandingsErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/DriverStandingsErgast").WithTags(nameof(DriverStandingsErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.driverStandings.ToListAsync();
            })
            .WithName("GetAllDriverStandingsErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<DriverStandingsErgast>, NotFound>> (int driverstandingsid, FormulaContext db) =>
            {
                return await db.driverStandings.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.driverStandingsId == driverstandingsid)
                    is DriverStandingsErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetDriverStandingsErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int driverstandingsid, DriverStandingsErgast driverStandingsErgast, FormulaContext db) =>
            {
                var affected = await db.driverStandings
                    .Where(model => model.driverStandingsId == driverstandingsid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.driverStandingsId, driverStandingsErgast.driverStandingsId)
                      .SetProperty(m => m.raceId, driverStandingsErgast.raceId)
                      .SetProperty(m => m.driverId, driverStandingsErgast.driverId)
                      .SetProperty(m => m.points, driverStandingsErgast.points)
                      .SetProperty(m => m.position, driverStandingsErgast.position)
                      .SetProperty(m => m.positionText, driverStandingsErgast.positionText)
                      .SetProperty(m => m.wins, driverStandingsErgast.wins)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateDriverStandingsErgast")
            .WithOpenApi();

            group.MapPost("/", async (DriverStandingsErgast driverStandingsErgast, FormulaContext db) =>
            {
                db.driverStandings.Add(driverStandingsErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/DriverStandingsErgast/{driverStandingsErgast.driverStandingsId}", driverStandingsErgast);
            })
            .WithName("CreateDriverStandingsErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int driverstandingsid, FormulaContext db) =>
            {
                var affected = await db.driverStandings
                    .Where(model => model.driverStandingsId == driverstandingsid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteDriverStandingsErgast")
            .WithOpenApi();
        }
    }
}