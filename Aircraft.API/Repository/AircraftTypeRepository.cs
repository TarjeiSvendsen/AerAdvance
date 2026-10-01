using Aircraft.API.Data;
using Aircraft.API.DTO;
using Aircraft.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Aircraft.API.Repository;

public class AircraftTypeRepository(AircraftDbContext dbContext): IAircraftTypeRepository
{
    public bool IsDbPopulated()
    {
        return dbContext.AircraftTypes.Any();
    }

    public async Task<PublicAircraftTypeDto> GetDtoByIcao(string icao)
    {
        return await dbContext.AircraftTypes.Where(a => a.Icao == icao).Select(at => new PublicAircraftTypeDto
        {
            Iata = at.Iata,
            Icao = at.Icao,
            Manufacturer = at.Manufacturer,
            Model = at.Model
        }).FirstAsync();
    }

    public Task<PublicAircraftTypeDto> GetDtoByIcaoOrIata(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public async Task<AircraftType> GetByIcao(string icao)
    {
        return await dbContext.AircraftTypes.Where(a => a.Icao == icao).FirstAsync();;
    }

    public Task<AircraftType> GetByIcaoOrIata(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PublicAircraftTypeDto>> GetAllTypes()
    {
        return await dbContext.AircraftTypes.Select(at => new PublicAircraftTypeDto()
        {
            Iata = at.Iata,
            Icao = at.Icao,
            Manufacturer = at.Manufacturer,
            Model = at.Model
        }).ToListAsync();
    }

    public async Task SaveAll(List<AircraftType> types)
    {
        await dbContext.AddRangeAsync(types);
        await dbContext.SaveChangesAsync();
    }
}