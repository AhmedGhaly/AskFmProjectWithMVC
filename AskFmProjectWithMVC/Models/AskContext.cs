using Microsoft.EntityFrameworkCore;

namespace AskFmProjectWithMVC.Models
{
    public class AskContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=.;Initial Catalog=ask;Integrated Security=True;TrustServerCertificate=true;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>().HasKey(k => new {k.follower_user_id, k.following_user_id});
            modelBuilder.Entity<Follow>()
                                          .HasOne<User>(t => t.following_user)
                                          .WithMany(t => t.following)
                                          .HasForeignKey(t => t.following_user_id)
                                          .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Follow>()
                              .HasOne<User>(t => t.follower_user)
                              .WithMany(t => t.follower)
                              .HasForeignKey(t => t.follower_user_id)
                              .OnDelete(DeleteBehavior.NoAction);
        }


        public virtual DbSet<Answer> answers { get; set; }
        public virtual DbSet<Question> questions { get; set; }
        public virtual DbSet<Follow> follows { get; set; }
        public virtual DbSet<Like> likes { get; set; }
        public virtual DbSet<User> users { get; set; }
    }
}
