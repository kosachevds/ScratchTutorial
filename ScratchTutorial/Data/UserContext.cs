using System.Data.Entity;

namespace ScratchTutorial.Data
{
    class UserContext : DbContext
    {
        public UserContext() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }
    }
}
