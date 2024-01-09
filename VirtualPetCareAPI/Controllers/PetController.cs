using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Repository.Context;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("/api/pets")]
    public class PetController : ControllerBase
    {
        private readonly PetCareDbContext _petCareDbContext;
        private readonly IMapper _mapper;



        public PetController(PetCareDbContext petCareDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _petCareDbContext = petCareDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<PetCreateDto>> PostPet(PetCreateDto petDto)
        {
            var pet = _mapper.Map<PetCreateDto, Pet>(petDto);
  


            _petCareDbContext.Pets.Add(pet);
            await _petCareDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { petId = pet.Id }, pet);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return Ok(await _petCareDbContext.Pets.ToListAsync());
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<Pet>> GetPet(int petId)
        {
            var pet = await _petCareDbContext.Pets.FindAsync(petId);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);    
        }
    }
}
