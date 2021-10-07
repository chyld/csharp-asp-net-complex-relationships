using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace web
{
  public class Database : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }

    public Database(DbContextOptions<Database> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      // options.EnableSensitiveDataLogging();
      // options.LogTo(Console.WriteLine, LogLevel.Debug);
      // other logging option
      // options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // this works too for configuring the relationship between entities

      // modelBuilder.Entity<User>().HasMany(user => user.SentMessages).WithOne(message => message.FromUser);
      // modelBuilder.Entity<User>().HasMany(user => user.ReceivedMessages).WithOne(message => message.ToUser);
    }
  }
}
