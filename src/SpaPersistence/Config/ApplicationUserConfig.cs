using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpaModel.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaPersistence.Config
{
    public class ApplicationUserConfig
    {
        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.HasMany(x => x.UserRoles)
                         .WithOne(x => x.User)
                         .HasForeignKey(x => x.UserId)
                         .IsRequired();
        }
    }
}
