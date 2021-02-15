using demo_mta_fares.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.Context
{

    public class TripDbContext : DbContext
    {
        public DbSet<DataTrip> DataTrips { get; set; }
        public DbSet<TaxiZone> TaxiZones { get; set; }

        public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<DataTrip>().ToTable("data_trip");
            modelBuilder.Entity<TaxiZone>().ToTable("taxi_zone");

            // Configure Primary Keys  
            modelBuilder.Entity<DataTrip>().HasKey(ug => ug.TripId).HasName("PRIMARY");
            modelBuilder.Entity<TaxiZone>().HasKey(u => u.LocationId).HasName("PRIMARY");

            // Configure indexes  
            modelBuilder.Entity<DataTrip>().HasIndex(p => p.TripId).IsUnique().HasDatabaseName("trip_id");
            modelBuilder.Entity<TaxiZone>().HasIndex(u => u.LocationId).IsUnique().HasDatabaseName("location_id");

            // Configure relationships  
            modelBuilder.Entity<DataTrip>().HasOne<TaxiZone>(x => x.PickupTaxiZone);
            modelBuilder.Entity<DataTrip>().HasOne<TaxiZone>(x => x.DropOffTaxiZone);
            modelBuilder.Entity<DataTrip>().Navigation(x => x.PickupTaxiZone).UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<DataTrip>().Navigation(x => x.DropOffTaxiZone).UsePropertyAccessMode(PropertyAccessMode.Property);

        }

    }
}
