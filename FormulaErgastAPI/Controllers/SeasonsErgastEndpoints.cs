
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FormulaErgastAPI.Models;

namespace FormulaErgastAPI.Controllers
{
    public static class SeasonsErgastEndpoints
    {
        public static void MapSeasonsErgastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/SeasonsErgast").WithTags(nameof(SeasonsErgast));

            group.MapGet("/", async (FormulaContext db) =>
            {
                return await db.seasons.ToListAsync();
            })
            .WithName("GetAllSeasonsErgasts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<SeasonsErgast>, NotFound>> (int year, FormulaContext db) =>
            {
                return await db.seasons.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.year == year)
                    is SeasonsErgast model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetSeasonsErgastById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int year, SeasonsErgast seasonsErgast, FormulaContext db) =>
            {
                var affected = await db.seasons
                    .Where(model => model.year == year)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.year, seasonsErgast.year)
                      .SetProperty(m => m.url, seasonsErgast.url)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateSeasonsErgast")
            .WithOpenApi();

            group.MapPost("/", async (SeasonsErgast seasonsErgast, FormulaContext db) =>
            {
                db.seasons.Add(seasonsErgast);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/SeasonsErgast/{seasonsErgast.year}", seasonsErgast);
            })
            .WithName("CreateSeasonsErgast")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int year, FormulaContext db) =>
            {
                var affected = await db.seasons
                    .Where(model => model.year == year)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteSeasonsErgast")
            .WithOpenApi();
        }
    }
}