using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.src.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SocialMedia.Infrastructure.src.Data
{
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext( DbContextOptions<SocialMediaContext> options)
            :base(options)
        {

        }



        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securities { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
