using Aircraft.API.DTO;
using Aircraft.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Aircraft.API.Controllers;

[ApiController]
public class TypeController(AircraftTypeService typeService): ControllerBase
{

    [HttpGet("types")]
    public async Task<List<PublicAircraftTypeDto>> GetBasicTypes()
    {
        return await typeService.GetAllAircraftTypes();
    } 
}