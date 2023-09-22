
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class DriversErgastEndpoints
    {
        public static void MapDriversErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/DriversErgast").WithTags(nameof(DriversErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.drivers.ToListAsync();
            })
            .WithName("GetAllDriversErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<DriversErgast>, NotFound>> (int driverid, FormulaContext db) =>
            {
                return await db.drivers.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.driverId == driverid)
                    is DriversErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetDriversErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int driverid, DriversErgast driversErgast, FormulaContext db) =>
            {
                var affected = await db.drivers
                    .Where(model => model.driverId == driverid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.driverId, driversErgast.driverId)
                      .SetProperty(m => m.driverRef, driversErgast.driverRef)
                      .SetProperty(m => m.number, driversErgast.number)
                      .SetProperty(m => m.code, driversErgast.code)
                      .SetProperty(m => m.forename, driversErgast.forename)
                      .SetProperty(m => m.surname, driversErgast.surname)
                      .SetProperty(m => m.dob, driversErgast.dob)
                      .SetProperty(m => m.nationality, driversErgast.nationality)
                      .SetProperty(m => m.url, driversErgast.url)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateDriversErgast")
            .WithOpenApi();

            group.MapPost("/", async (DriversErgast driversErgast, FormulaContext db) =>
            {
                db.drivers.Add(driversErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/DriversErgast/{driversErgast.driverId}", driversErgast);
            })
            .WithName("CreateDriversErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int driverid, FormulaContext db) =>
            {
                var affected = await db.drivers
                    .Where(model => model.driverId == driverid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteDriversErgast")
            .WithOpenApi();
        }
    }
}