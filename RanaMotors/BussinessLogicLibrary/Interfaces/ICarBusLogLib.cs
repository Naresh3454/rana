using BussinessLogicLibrary.Entities;
using System.Collections.Generic;
using DataAccessLibrary.Models;

namespace BussinessLogicLibrary.Interfaces
{
    public interface ICarBusLogLib
    {
        IEnumerable<CarEntity> GetUsedCarsList();
        IEnumerable<CarEntity> GetNewCarsList();

        bool CreateCar(CarEntity CarDetails);
        bool EditCar(int CarId);
        bool UpdateCar(int CarId, CarEntity UpdatedCarDetails);
        bool DeleteCar(int CarId,CarEntity DeleteCarDetails);
        CarEntity GetById(int CarId);
    }
}
