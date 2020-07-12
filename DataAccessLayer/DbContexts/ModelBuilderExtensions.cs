using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbContexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Step>().HasData
                (new Step { Id = 1, Name = "Step1" },
                new Step { Id = 2, Name = "Step2" }
                );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Title = "Item 1", Description = "item 1", StepId = 1 },
            new Item { Id = 2, Title = "Item 2", Description = "Item 2", StepId = 2 });
        }
    }
}
