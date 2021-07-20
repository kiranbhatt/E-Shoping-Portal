namespace ApplicationCore.Migrations
{
    using DomainModels.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationCore.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationCore.DatabaseContext context)
        {
            Category category1 = new Category() { Name = "Books" };
            Category category2 = new Category() { Name = "Toys" };
            context.Categories.Add(category1);
            context.Categories.Add(category2);

            Role role1 = new Role() { Name = "Admin", Description = "Administrator" };
            Role role2 = new Role() { Name = "User", Description = "End User" };

            User user1 = new User()
            {
                Username = "Admin",
                Name = "admin",
                Password = "1234",
                ContactNo = "9876543210",
                Address = "Noida"
            };
            User user2 = new User()
            {
                Username = "User",
                Name = "user",
                Password = "1234",
                ContactNo = "9876543210",
                Address = "Noida"
            };
            user1.Roles.Add(role1);

            user2.Roles.Add(role2);
            context.Users.Add(user1);
            context.Users.Add(user2);

        }
    }
}
