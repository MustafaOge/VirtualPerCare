using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.Pet
{
    public class PetUpdateDto : BaseModelDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid UserId { get; set; }

    }
}
