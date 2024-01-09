using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VirtualPetCare.Repository.Context;
using VirtualPetCareAPI.Entities;


namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthStatusesController : ControllerBase
    {
        private readonly PetCareDbContext _context;

        public HealthStatusesController(PetCareDbContext context)
        {
            _context = context;
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<HealthStatus>> GetHealthStatus(Guid petId)
        {
            var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(h => h.PetId == petId);
            if (healthStatus == null)
            {
                return NotFound();
            }

            return healthStatus;
        }

        [HttpPatch("{petId}")]
        public async Task<IActionResult> UpdateHealthStatus(Guid petId, HealthStatus healthStatusUpdate)
        {
            var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(h => h.PetId == petId);
            if (healthStatus == null)
            {
                return NotFound();
            }

            healthStatus.Status = healthStatusUpdate.Status;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
