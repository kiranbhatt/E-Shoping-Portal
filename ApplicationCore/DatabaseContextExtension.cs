using DomainModels.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ApplicationCore
{
    public static class DatabaseContextExtension
    {
        public static DbModelBuilder AddEntityMapping(this DbModelBuilder modelBuilder)
        {
           // Issue : https://stackoverflow.com/questions/17127351/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //m:m
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(m => m.Users).Map((k) =>
            {
                k.MapLeftKey("UserId");
                k.MapRightKey("RoleId");
                k.ToTable("UserRoles");
            });

            return modelBuilder;
        }
    }
}
