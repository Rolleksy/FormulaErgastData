
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class QualifyingErgastEndpoints
    {
        public static void MapQualifyingErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/QualifyingErgast").WithTags(nameof(QualifyingErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.QualifyingErgast.ToListAsync();
            })
            .WithName("GetAllQualifyingErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<QualifyingErgast>, NotFound>> (int qualifyid, FormulaContext db) =>
            {
                return await db.QualifyingErgast.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.qualifyId == qualifyid)
                    is QualifyingErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetQualifyingErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int qualifyid, QualifyingErgast qualifyingErgast, FormulaContext db) =>
            {
                var affected = await db.QualifyingErgast
                    .Where(model => model.qualifyId == qualifyid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.qualifyId, qualifyingErgast.qualifyId)
                      .SetProperty(m => m.raceId, qualifyingErgast.raceId)
                      .SetProperty(m => m.driverId, qualifyingErgast.driverId)
                      .SetProperty(m => m.constructorId, qualifyingErgast.constructorId)
                      .SetProperty(m => m.number, qualifyingErgast.number)
                      .SetProperty(m => m.position, qualifyingErgast.position)
                      .SetProperty(m => m.q1, qualifyingErgast.q1)
                      .SetProperty(m => m.q2, qualifyingErgast.q2)
                      .SetProperty(m => m.q3, qualifyingErgast.q3)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateQualifyingErgast")
            .WithOpenApi();

            group.MapPost("/", async (QualifyingErgast qualifyingErgast, FormulaContext db) =>
            {
                db.QualifyingErgast.Add(qualifyingErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/QualifyingErgast/{qualifyingErgast.qualifyId}", qualifyingErgast);
            })
            .WithName("CreateQualifyingErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int qualifyid, FormulaContext db) =>
            {
                var affected = await db.QualifyingErgast
                    .Where(model => model.qualifyId == qualifyid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteQualifyingErgast")
            .WithOpenApi();
        }
    }
}