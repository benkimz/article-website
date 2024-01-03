﻿using Applantus.Tingum.Core.CoreCanvas.AppUsers;
using Applantus.Tingum.Core.CoreCanvas.Articles;
using Applantus.Tingum.Core.CoreCanvas.Articles.Tags;
using Microsoft.EntityFrameworkCore;

namespace Applantus.Tingum.Infrastruture.Data;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; } 

    public DbSet<Article> Articles { get; set; } 

    public DbSet<ArticleTag> ArticleTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("tingum");

        modelBuilder.Entity<AppUser>()
            .HasIndex(i => i.UserName)
            .IsUnique();

        modelBuilder.Entity<AppUser>()
            .HasIndex(i => i.Email)
            .IsUnique();

        modelBuilder.Entity<Article>()
            .HasMany(a => a.Tags)
            .WithMany()
            .UsingEntity(j => j.ToTable("ArticleTagMap"));
    }
}
