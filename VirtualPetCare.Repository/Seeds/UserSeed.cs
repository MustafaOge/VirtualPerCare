using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareAPI.Entities;


namespace VirtualPetCare.Repository.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Name = "Ali", Email = "Ali12@gmail.com" },
                new User { Id = 2, Name = "Mehmet", Email = "Mehmet@gmail.com" },
                new User { Id = 3, Name = "Ayşe", Email = "ayşe@gmail.com" },
                new User { Id = 4, Name = "Zeynep", Email = "zeynep@gmail.com" }
                );
        }
    }
}
