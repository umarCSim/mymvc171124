using Microsoft.EntityFrameworkCore;
using MyMVC161124.Models;

namespace MyMVC161124.Data
{
    public class CatContext : DbContext
    {
        public DbSet<CatImages> CatsImages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("LocalDB");
        }
    }
}
