using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCare.Core.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int id);
        List<Pet> GetPetsById(int id);


    }
}
