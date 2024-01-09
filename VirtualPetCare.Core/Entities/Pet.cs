using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareAPI.Entities
{
    public class Pet : BaseEntity
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }


      

    }
}
