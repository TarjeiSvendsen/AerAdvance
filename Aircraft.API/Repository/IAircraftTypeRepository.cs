using System.Collections.ObjectModel;
using Aircraft.API.DTO;
using Aircraft.API.Model;

namespace Aircraft.API.Repository;

public interface IAircraftTypeRepository
{
    public bool IsDbPopulated();
    public Task<PublicAircraftTypeDto> GetDtoByIcao(string icao);
    public Task<PublicAircraftTypeDto> GetDtoByIcaoOrIata(string searchTerm);
    public Task<AircraftType> GetByIcao(string icao);
    public Task<AircraftType> GetByIcaoOrIata(string searchTerm);
    public Task<List<PublicAircraftTypeDto>> GetAllTypes();
    public Task SaveAll(List<AircraftType> types);
}