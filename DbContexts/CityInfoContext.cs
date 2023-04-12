using CityInfo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Api.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointOfInterest { get; set; } = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("City 1")
                {
                    Id = 1,
                    Description = "City 1 description"
                },
                new City("City 2")
                {
                    Id = 2,
                    Description = "City 2 description"
                },
                new City("City 3")
                {
                    Id = 3,
                    Description = "City 3 description"
                }
            );

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("PointOfInterest 1")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "PointOfInterest 1 description"
                },
                new PointOfInterest("PointOfInterest 2")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "PointOfInterest 2 description"
                },
                new PointOfInterest("PointOfInterest 3")
                {
                    Id = 3,
                    CityId = 1,
                    Description = "PointOfInterest 3 description"
                },
                new PointOfInterest("PointOfInterest 3")
                {
                    Id = 4,
                    CityId = 2,
                    Description = "PointOfInterest 3 description"
                },
                new PointOfInterest("PointOfInterest 3")
                {
                    Id = 5,
                    CityId = 3,
                    Description = "PointOfInterest 3 description"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}