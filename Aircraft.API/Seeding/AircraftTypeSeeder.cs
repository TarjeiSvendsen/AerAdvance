using System.Text.Json;
using Aircraft.API.Model;
using Aircraft.API.Service;

namespace Aircraft.API.Seeding;

public class AircraftTypeSeeder(AircraftTypeService aircraftTypeService)
{
    public async Task ImportAll()
    {
        if (aircraftTypeService.AircraftTypesExistInDb())
        {
            Console.WriteLine("Skipping Import");
            return;
        }

        var files = Directory.GetFiles("Resources/Aircraft/","*.json",SearchOption.AllDirectories);
        List<AircraftType> aircraftTypes = new List<AircraftType>(files.Length);
        aircraftTypes.AddRange(files.Select(async fileName => await File.ReadAllTextAsync(fileName))
        .Select(file => JsonElement.Parse(file.Result))
        .Select(element => new AircraftType
        {
            Id = Guid.CreateVersion7(),
            Model = element.GetProperty("model").ToString(),
            Iata = element.GetProperty("iata").ToString(),
            Icao = element.GetProperty("icao").ToString(),
            Manufacturer = element.GetProperty("manufacturer").ToString(),
            Description = element.GetProperty("description").ToString(),
            BodyType = element.GetProperty("bodyType").ToString()
        }));
        await aircraftTypeService.SaveCollection(aircraftTypes);
    }
}