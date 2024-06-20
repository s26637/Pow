using Microsoft.EntityFrameworkCore;
using Powtórka.Models;

namespace Powtórka.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext(){}

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Item> Items { get; set; }
    public DbSet<Chatacter> Chatacters { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Sword",
                Weight = 5
            },
            
            new Item
            {
                Id = 2,
                Name = "Axe",
                Weight = 6
            },
            new Item
            {
                Id = 3,
                Name = "XXX",
                Weight = 1
            },
            new Item
            {
                Id = 4,
                Name = "BBB",
                Weight = 2
            },
            new Item
            {
                Id = 5,
                Name = "CCC",
                Weight = 10
            } 
            
        });
        
        
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
          new Title
          {
              Id = 1,
              Name = "Title1"
          },
          new Title
          {
              Id = 2,
              Name = "Title2"
          },
          new Title
          {
              Id = 3,
              Name = "Title3"
          }
        });
        
        modelBuilder.Entity<Chatacter>().HasData(new List<Chatacter>
        {
         new Chatacter
         {
             Id = 1,
             FirstName = "Mark",
             LastName = "Kowalski",
             CurrentWei = 0,
             MaxWeight = 100
         },
         new Chatacter
         {
         Id = 2,
         FirstName = "Tomek",
         LastName = "Adamski",
         CurrentWei = 90,
         MaxWeight = 100
        }
        });
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
         new Backpack
         {
             CharacterId = 2,
             ItemId = 1,
             Amount = 5
         },
         new Backpack
         {
         CharacterId = 1,
         ItemId = 1,
         Amount = 10
        },
         new Backpack
         {
         CharacterId = 1,
         ItemId = 2,
         Amount = 5
        }
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
            new CharacterTitle
            {
               CharacterId = 1,
               TitleId = 1,
               AcquiredAt = DateTime.Parse("2022-04-03")
            },
            
            new CharacterTitle
            {
            CharacterId = 1,
            TitleId = 2,
            AcquiredAt = DateTime.Parse("2019-04-03")
            },
            new CharacterTitle
            {
                CharacterId = 1,
                TitleId = 3,
                AcquiredAt = DateTime.Parse("2015-04-03")
            }
            
            
        });
        
    }
}