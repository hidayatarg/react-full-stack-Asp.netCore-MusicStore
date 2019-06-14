using System;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =react;Password=react; Server=116.203.116.183;Port=5432;Database=react-music-store;Integrated Security=true;Pooling=true;");
        }
        // DbSets
        public DbSet<Music> Musics { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
