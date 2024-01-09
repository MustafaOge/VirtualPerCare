using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.SocialInteraction
{
    public class SocialInteractionDto : BaseModelDto
    {
        public string Type { get; set; }
        public DateTime InteractionTime { get; set; }
    }
}
