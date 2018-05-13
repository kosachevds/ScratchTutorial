using System.Data.Entity;

namespace ScratchTutorial
{
    class UserContext : DbContext
    {
        public UserContext() : base("DbConnection") { }

        public DbSet<UserData> Users { get; set; }
    }
}
