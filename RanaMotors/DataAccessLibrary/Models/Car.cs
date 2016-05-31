using DataAccessLibrary.Enums;

namespace DataAccessLibrary.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public string CarType { get; set; }
        public int YearOfmanufacture { get; set; }
        public bool IsNewCar { get; set; }
        public FuelType FuelType { get; set; }
    }
}
