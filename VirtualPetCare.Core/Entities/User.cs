namespace VirtualPetCareAPI.Entities
{
    public class User  : BaseEntity<int>
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Pet> Pets { get; set; }


    }
}


