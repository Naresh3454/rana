using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using BussinessLogicLibrary.Entities;

namespace BussinessLogicLibrary.Interfaces
{
    public interface IAdvertiseCarBusLogLib
    {
        IEnumerable<AdvertiseCarEntity> GetUsedCarsList();
        IEnumerable<AdvertiseCarEntity> GetNewCarsList();

        bool CreateAdvertiseCar(AdvertiseCarEntity advertiseCar);
        bool EditAdvertisedCar(int CarId);
        bool UpdateAdvertisedCar(int CarId, AdvertiseCarEntity UpdatedCarDetails);
        bool DeleteAdvertisedCar(int CarId, AdvertiseCarEntity DeleteCarDetails);
        AdvertiseCarEntity GetById(int CarId);

    }
}

