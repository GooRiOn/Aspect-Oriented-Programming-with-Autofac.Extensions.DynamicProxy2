using System.Data.Entity;

namespace AOP.Database
{
    public class Context : DbContext
    {
        static Context()
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public Context() : base(nameof(Context))
        {
        }

        public DbSet<ItemEntity> Items { get; set; }
    }
}