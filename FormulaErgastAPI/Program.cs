
using FormulaErgastAPI.Data;
using Microsoft.AspNetCore.OpenApi;
using FormulaErgastAPI.Controllers;
using FormulaErgastConsole.Services;
using ErgastModels.Models;
using FormulaErgastAPI.Models;
using Microsoft.Data.SqlClient;

namespace FormulaErgastAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<FormulaContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

                        app.MapCircuitErgastEndpoints();

                        app.MapConstructorResultsErgastEndpoints();

                        app.MapConstructorsErgastEndpoints();

                        app.MapConstructorStandingsErgastEndpoints();

                        app.MapDriversErgastEndpoints();

                        app.MapDriverStandingsErgastEndpoints();

                        app.MapLapTimesErgastEndpoints();

                        app.MapPitStopsErgastEndpoints();

                        app.MapQualifyingErgastEndpoints();

                        app.MapRacesErgastEndpoints();

                        app.MapResultsErgastEndpoints();

                        app.MapSeasonsErgastEndpoints();

                        app.MapSprintResultsErgastEndpoints();

                        app.MapStatusErgastEndpoints();
            //AddDrivers();
            //AddCircuits();
            //AddConstructors();
            //AddConstructorStandings();
            //AddConstructorResults();
            AddDriverStandings();
            /*AddLapTimes();
            AddPitStops();
            AddQualifying();
            AddRaces();
            AddResults();
            AddSeasons();
            AddSprintResults();
            AddStatuses();*/
            app.Run();
        }

        /*private static void AddPitStops()
        {
            CSVtoObject cvs = new CSVtoObject();
            List<FormulaErgastAPI.Models.PitStopsErgast> pitStops = cvs.GetObjectsFromCSV<FormulaErgastAPI.Models.PitStopsErgast>("pit_stops");
            foreach (FormulaErgastAPI.Models.PitStopsErgast pitStop in pitStops)
            {

                using (var context = new FormulaContext())
                {
                    pitStop. = 0;
                    context.driverStandings.Add(driverStanding);
                    context.SaveChanges();
                }
            }
        }*/

        private static void AddDriverStandings()
        {
            CSVtoObject cvs = new CSVtoObject();
            List<FormulaErgastAPI.Models.DriverStandingsErgast> driverStandings = cvs.GetObjectsFromCSV<FormulaErgastAPI.Models.DriverStandingsErgast>("driver_standings");
            foreach (FormulaErgastAPI.Models.DriverStandingsErgast driverStanding in driverStandings)
            {

                using (var context = new FormulaContext())
                {
                    driverStanding.driverStandingsId = 0;
                    context.driverStandings.Add(driverStanding);
                    context.SaveChanges();
                }
            }
        }

        private static void AddCircuits()
        {
            CSVtoObject cvs = new CSVtoObject();
            List<FormulaErgastAPI.Models.CircuitErgast> circuits = cvs.GetObjectsFromCSV<FormulaErgastAPI.Models.CircuitErgast>("circuits");
            foreach (FormulaErgastAPI.Models.CircuitErgast circuit in circuits)
            {

                using (var context = new FormulaContext())
                {
                    circuit.circuitId = 0;
                    context.circuits.Add(circuit);
                    context.SaveChanges();
                }
            }
        }
        private static void AddConstructorStandings()
        {
            CSVtoObject cvs = new CSVtoObject();
            List<FormulaErgastAPI.Models.ConstructorStandingsErgast> constructorStandings = cvs.GetObjectsFromCSV<FormulaErgastAPI.Models.ConstructorStandingsErgast>("constructor_standings");
            foreach (FormulaErgastAPI.Models.ConstructorStandingsErgast constructor in constructorStandings)
            {

                using (var context = new FormulaContext())
                {
                    constructor.constructorStandingsId = 0;
                    context.constructorStandings.Add(constructor);
                    context.SaveChanges();
                }
            }
        }
        private static void AddConstructorResults()
        {
            CSVtoObject cvs = new CSVtoObject();
            List<FormulaErgastAPI.Models.ConstructorResultsErgast> constructorResults = cvs.GetObjectsFromCSV<FormulaErgastAPI.Models.ConstructorResultsErgast>("constructor_results");
            foreach (FormulaErgastAPI.Models.ConstructorResultsErgast constructor in constructorResults)
            {

                using (var context = new FormulaContext())
                {
                    constructor.constructorResultsId = 0;
                    context.constructorResults.Add(constructor);
                    context.SaveChanges();
                }
            }
        }
        private static void AddConstructors()
        {
            CSVtoObject cvs = new CSVtoObject();
            List<FormulaErgastAPI.Models.ConstructorsErgast> constructors = cvs.GetObjectsFromCSV<FormulaErgastAPI.Models.ConstructorsErgast>("constructors");
            foreach (FormulaErgastAPI.Models.ConstructorsErgast constructor in constructors)
            {

                using (var context = new FormulaContext())
                {
                    constructor.constructorId= 0;
                    context.constructors.Add(constructor);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Configuration methods - used to add data to DB. Use only if tables are empty
        /// </summary>
        private static void AddDrivers()
        {
            CSVtoObject cvs = new CSVtoObject();
            List<FormulaErgastAPI.Models.DriversErgast> drivers = cvs.GetObjectsFromCSV<FormulaErgastAPI.Models.DriversErgast>("drivers");
            foreach (FormulaErgastAPI.Models.DriversErgast driver in drivers)
            {

                using (var context = new FormulaContext())
                {
                    driver.driverId = 0;
                    context.drivers.Add(driver);
                    context.SaveChanges();
                }
            }
        }
        
    }
}