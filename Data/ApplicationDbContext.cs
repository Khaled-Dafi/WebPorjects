//we create this class to handle the database Configaration with the model/Category
using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    { 
        // now you will get the  connection stirng  ctor for constrocator

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        
        {
        
        
        }

        // to crate table in the db you need to add this to ApplactionDbConectxt.cs Class in the Data Folder
                
                 //ModelClass  //TableName
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                
               new Category {Id = 1, Name="Action", DisplayOrder = 1},
               new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
               new Category { Id = 3, Name = "Action", DisplayOrder = 3 }
                );
        }
    }
    }

// now you will need to registers this into the program.cs