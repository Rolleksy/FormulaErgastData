
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class CircuitErgastEndpoints
    {
        public static void MapCircuitErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/CircuitErgast").WithTags(nameof(CircuitErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.circuits.ToListAsync();
            })
            .WithName("GetAllCircuitErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<CircuitErgast>, NotFound>> (int circuitid, FormulaContext db) =>
            {
                return await db.circuits.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.circuitId == circuitid)
                    is CircuitErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetCircuitErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int circuitid, CircuitErgast circuitErgast, FormulaContext db) =>
            {
                var affected = await db.circuits
                    .Where(model => model.circuitId == circuitid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.circuitId, circuitErgast.circuitId)
                      .SetProperty(m => m.circuitRef, circuitErgast.circuitRef)
                      .SetProperty(m => m.name, circuitErgast.name)
                      .SetProperty(m => m.location, circuitErgast.location)
                      .SetProperty(m => m.country, circuitErgast.country)
                      .SetProperty(m => m.lat, circuitErgast.lat)
                      .SetProperty(m => m.lng, circuitErgast.lng)
                      .SetProperty(m => m.alt, circuitErgast.alt)
                      .SetProperty(m => m.url, circuitErgast.url)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateCircuitErgast")
            .WithOpenApi();

            group.MapPost("/", async (CircuitErgast circuitErgast, FormulaContext db) =>
            {
                db.circuits.Add(circuitErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/CircuitErgast/{circuitErgast.circuitId}", circuitErgast);
            })
            .WithName("CreateCircuitErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int circuitid, FormulaContext db) =>
            {
                var affected = await db.circuits
                    .Where(model => model.circuitId == circuitid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteCircuitErgast")
            .WithOpenApi();
        }
    }
}