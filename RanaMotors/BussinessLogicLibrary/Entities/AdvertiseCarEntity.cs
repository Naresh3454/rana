using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Enums;

namespace BussinessLogicLibrary.Entities
{
   public class AdvertiseCarEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public int OdoMeterReading { get; set; }
        public int ManufacturedYear { get; set; }
        public int SellingPrice { get; set; }
        public int Contact { get; set; }
        public byte[] picture { get; set; }
        public bool IsNewCar { get; set; }
        public FuelType FuelType { get; set; }
    }

}
