using DataAccessLibrary.Enums;
namespace DataAccessLibrary.Models
{
   public class AdvertiseCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CompanyName { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public int OdoMeterReading { get; set; }
        public int ManufacturedYear { get; set; }
        public int SellingPrice { get; set; }
        public int Contact { get; set; }
        public byte[] picture { get; set; }
        public FuelType FuelType { get; set; }

    }
}
