using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs
{
    public abstract class BaseModelDto
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
    }
}
