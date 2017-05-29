#region Using

using Microsoft.EntityFrameworkCore;

#endregion

namespace MyMVCProject.Models.Database
{
    public class DataBaseContext : DbContext
    {
        //public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            base.OnModelCreating(modelBuilder);  
            new User(modelBuilder.Entity <User> ());
        }  
    }
}
        