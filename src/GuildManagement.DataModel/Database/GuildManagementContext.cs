using GuildManagement.Framework;
using Microsoft.Data.Entity;

namespace GuildManagement.DataModel
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class GuildManagementContext : DbContext
    {
        public GuildManagementContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Guild> Guilds { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}