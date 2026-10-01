using Aircraft.API.DTO;
using Aircraft.API.Model;
using Aircraft.API.Repository;

namespace Aircraft.API.Service;

public class AircraftTypeService(IAircraftTypeRepository typeRepository)
{
    public bool AircraftTypesExistInDb()
    {
        return typeRepository.IsDbPopulated();
    }
    public async Task<List<PublicAircraftTypeDto>> GetAllAircraftTypes()
    {
        return await typeRepository.GetAllTypes();
    }

    public async Task<PublicAircraftTypeDto> GetAircraftTypeDtoByIcao(string icao)
    {
        return await typeRepository.GetDtoByIcao(icao);
    }

    public async Task SaveCollection(List<AircraftType> types)
    {
        await typeRepository.SaveAll(types);
    }

}