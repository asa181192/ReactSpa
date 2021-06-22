using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpaModel.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaPersistence.Config
{
    public class ApplicationRoleConfig
    {
        public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            entityBuilder.HasMany(x => x.UserRoles)
                         .WithOne(x => x.Role)
                         .HasForeignKey(x => x.RoleId)
                         .IsRequired();
        }
    }
}
