using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using VirtualPetCare.Core.DTOs.Activity;
using VirtualPetCare.Repository.Context;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly PetCareDbContext _context;

        private readonly IMapper _mapper;


        public ActivitiesController(PetCareDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> PostActivity(PetActivity petActivity)
        {
            //var entity = _mapper.Map<PetActivityCreateDto, PetActivity>(pet);

            _context.Activities.Add(petActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivities), new { petId = petActivity.PetId }, petActivity);
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<IEnumerable<PetActivity>>> GetActivities(Guid petId)
        {
            var activities =  _context.Activities.Where(a => a.PetId == petId).FirstOrDefault();
            return Ok(activities);
        }
    }
}
