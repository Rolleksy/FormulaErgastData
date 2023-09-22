
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class StatusErgastEndpoints
    {
        public static void MapStatusErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/StatusErgast").WithTags(nameof(StatusErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.statuses.ToListAsync();
            })
            .WithName("GetAllStatusErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<StatusErgast>, NotFound>> (int statusid, FormulaContext db) =>
            {
                return await db.statuses.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.statusId == statusid)
                    is StatusErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetStatusErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int statusid, StatusErgast statusErgast, FormulaContext db) =>
            {
                var affected = await db.statuses
                    .Where(model => model.statusId == statusid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.statusId, statusErgast.statusId)
                      .SetProperty(m => m.status, statusErgast.status)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateStatusErgast")
            .WithOpenApi();

            group.MapPost("/", async (StatusErgast statusErgast, FormulaContext db) =>
            {
                db.statuses.Add(statusErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/StatusErgast/{statusErgast.statusId}", statusErgast);
            })
            .WithName("CreateStatusErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int statusid, FormulaContext db) =>
            {
                var affected = await db.statuses
                    .Where(model => model.statusId == statusid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteStatusErgast")
            .WithOpenApi();
        }
    }
}