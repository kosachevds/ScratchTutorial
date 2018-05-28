using System.Data.Entity;

namespace ScratchTutorial.Data
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }

        public DbSet<LessonStatistic> LessonHistory { get; set; }

        public DbSet<TestStatistic> TestHistory { get; set; }
    }
}
