using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualPetCare.Repository.Context;
using VirtualPetCareAPI.Entities;


namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly PetCareDbContext _context;

        public FoodsController( PetCareDbContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetFood>>> GetFoods()
        {
            var foods = await _context.PetFoods.ToArrayAsync();
            return Ok(foods);
        }

        [HttpPost]
        public async Task<ActionResult<PetFood>> PostFood(Guid petId, PetFood food)
        {
            var pet = await _context.Pets.FindAsync(petId);
            if (pet == null)
            {
                return NotFound();
            }
            food.PetId = petId;
            _context.PetFoods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFoods), new { id = food.Id }, food);
        }
    }
}
