using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Repository.Context;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCare.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetCareDbContext _context;
        public UserRepository(PetCareDbContext context)
        {
            _context = context;
            
        }

        public void Add(User user)
        {
            _context.Add(user);
        }



        public User GetById(int id)
        {
              return _context.Find(id);
        }

        public List<Pet> GetPetsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
