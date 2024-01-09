using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.Activity
{
    public class PetActivityDto
    {
        public string Name { get; set; }

        [Required]
        public Guid PetId { get; set; }
    }
}
