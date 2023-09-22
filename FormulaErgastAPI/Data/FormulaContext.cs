using FormulaErgastAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaErgastAPI.Data
{
    public class FormulaContext : DbContext
    {
        public DbSet<CircuitErgast> circuits { get; set; }
        public DbSet<ConstructorResultsErgast> constructorResults { get; set; }
        public DbSet<ConstructorsErgast> constructors { get; set; }
        public DbSet<ConstructorStandingsErgast> constructorStandings { get; set; }
        public DbSet<DriversErgast> drivers { get; set; }
        public DbSet<DriverStandingsErgast> driverStandings { get; set; }
        public DbSet<LapTimesErgast> lapTimes { get; set; }
        public DbSet<PitStopsErgast> pitStops { get; set; }
        public DbSet<RacesErgast> races { get; set; }
        public DbSet<ResultsErgast> results { get; set; }
        public DbSet<SeasonsErgast> seasons { get; set; }
        public DbSet<SprintResultsErgast> sprintResults { get; set; }
        public DbSet<StatusErgast> statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FormulaErgastDB;Trusted_Connection=True");
        }

        public DbSet<FormulaErgastAPI.Models.QualifyingErgast> QualifyingErgast { get; set; } = default!;
    }
}
