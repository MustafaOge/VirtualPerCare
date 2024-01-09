using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCare.Repository.Configurations

{
    public class UserLocalConfiguration : BaseEntityConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Name).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(255);

        }
    }
}
