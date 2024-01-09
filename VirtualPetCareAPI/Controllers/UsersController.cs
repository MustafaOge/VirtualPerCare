using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VirtualPetCare.Core;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Core.Repositories.User;
using VirtualPetCare.Repository.Context;
using VirtualPetCare.Repository.UnitOfWork;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly PetCareDbContext _context;
        private readonly IValidator<UserCreateDto> _validator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public UsersController(PetCareDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserCreateDto>> PostUser(UserCreateDto userDto)
        {

            var user = _mapper.Map<UserCreateDto, User>(userDto);

            _context.Users.Add(user);
             _unitOfWork.SaveChanges();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);

        }


        [HttpGet]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return user;

        }

        public Task<bool> AddAsync(User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(List<User> datas)
        {
            throw new NotImplementedException();
        }

        public bool Remove(User model)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<User> datas)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User model)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
