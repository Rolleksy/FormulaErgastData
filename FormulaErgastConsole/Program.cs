 using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.IO;
using System.Linq;
using ErgastModels.Models;
using FormulaErgastConsole.Services;

class Program
{
    static void Main()
    {
        CSVtoObject csv = new CSVtoObject();
        List<DriversErgast> drivers = csv.GetObjectsFromCSV<DriversErgast>("drivers");
        List<CircuitErgast> circuits = csv.GetObjectsFromCSV<CircuitErgast>("circuits");
        List<ConstructorResultsErgast> constructorResults = csv.GetObjectsFromCSV<ConstructorResultsErgast>("constructor_results");
        List<ConstructorStandingsErgast> constructorStandings = csv.GetObjectsFromCSV<ConstructorStandingsErgast>("constructor_standings");
        List<ConstructorsErgast> constructors = csv.GetObjectsFromCSV<ConstructorsErgast>("constructors");
        List<DriverStandingsErgast> driverStandings = csv.GetObjectsFromCSV<DriverStandingsErgast>("driver_standings");
        List<LapTimesErgast> lapTimes = csv.GetObjectsFromCSV<LapTimesErgast>("lap_times");
        List<PitStopsErgast> pitStops = csv.GetObjectsFromCSV<PitStopsErgast>("pit_stops");
        List<QualifyingErgast> qualifyings = csv.GetObjectsFromCSV<QualifyingErgast>("qualifying");
        List<RacesErgast> races = csv.GetObjectsFromCSV<RacesErgast>("races");
        List<ResultsErgast> results = csv.GetObjectsFromCSV<ResultsErgast>("results");
        List<SeasonsErgast> seasons = csv.GetObjectsFromCSV<SeasonsErgast>("seasons");
        List<SprintResultsErgast> sprintResults = csv.GetObjectsFromCSV<SprintResultsErgast>("sprint_results");
        List<StatusErgast> statuses = csv.GetObjectsFromCSV<StatusErgast>("status");

        Console.WriteLine(drivers.Count);
        Console.WriteLine(lapTimes.Count);
        Console.WriteLine(pitStops.Count);
        Console.WriteLine(qualifyings.Count);
        Console.WriteLine(races.Count);
        Console.WriteLine(results.Count);
        Console.WriteLine(seasons.Count);
        Console.WriteLine(sprintResults.Count);
        Console.WriteLine(circuits.Count);
        Console.WriteLine(constructorResults.Count);
        Console.WriteLine(statuses.Count);
        Console.WriteLine(constructorStandings.Count);
        Console.WriteLine(constructors.Count);
        Console.WriteLine(driverStandings.Count);





    }
}

 