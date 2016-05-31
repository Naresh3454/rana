using DataAccessLibrary.Enums;

namespace BussinessLogicLibrary.Entities
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public string CarType { get; set; }
        public int YearOfmanufacture { get; set; }
        public int OdoMeterReading { get; set; }
        public FuelType FuelType { get; set; }
        public bool IsNewCar { get; set; }
    }
}
