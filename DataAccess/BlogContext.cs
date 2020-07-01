using Microsoft.EntityFrameworkCore;
using System;
using Domain;
using EfDataAccess.Configurations;

namespace EfDataAccess
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<PostTag> PostTags { get; set; }        
        public DbSet<UserUseCase> UserUseCase { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Votes> Votes { get; set; }
        public DbSet<UseCaseLogs> UseCaseLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DJ-DUCI\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagsConfiguration());
            modelBuilder.ApplyConfiguration(new UserUseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseLogsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
            modelBuilder.ApplyConfiguration(new VotesConfiguration());

        }
    }
}
