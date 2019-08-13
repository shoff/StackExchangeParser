namespace StackExchangeParser.EF
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class StackExchangeDbContext : DbContext
    {
        public StackExchangeDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Badge> Badges { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostHistory> PostHistories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}