using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.Pet
{
    public class PetDto : BaseModelDto
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int Age { get; set; }
        public string HealthStatus { get; set; }
    }
}
