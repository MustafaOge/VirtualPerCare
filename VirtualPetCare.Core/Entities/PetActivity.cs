using System.ComponentModel.DataAnnotations;


namespace VirtualPetCareAPI.Entities
{
    public class PetActivity : BaseEntity
    {

        public string Name { get; set; }

        [Required]
        public Guid PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
