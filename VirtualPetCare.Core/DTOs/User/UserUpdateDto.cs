
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.User
{
    public class UserUpdateDto : BaseModelDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
