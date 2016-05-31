using DataAccessLibrary.Models;
using System.Data.Entity;

namespace DataAccessLibrary
{
    public class CarContext : DbContext
    {
        public CarContext()
            : base("CarContext")
        {
            Database.SetInitializer<CarContext>(new AppInitializer());

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static CarContext Create()
        {
            return new CarContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<AdvertiseCar> AdvertiseCars { get; set; }
    }
}
