using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCare.Core.Entities
{
    public class SocialInteraction  : BaseEntity
    {
        public string Type { get; set; }
        public DateTime InteractionTime { get; set; }
    }
}
