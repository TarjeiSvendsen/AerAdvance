using Microsoft.EntityFrameworkCore;

namespace AerAdvance.Finance.API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    
}