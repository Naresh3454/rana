using BussinessLogicLibrary.Interfaces;
using System;
using System.Collections.Generic;
using BussinessLogicLibrary.Entities;
using DataAccessLibrary;
using AutoMapper;
using DataAccessLibrary.Models;
using NLog;

namespace BussinessLogicLibrary.Implementation
{
    public class CarBusLogLib : ICarBusLogLib
    {
        private readonly UnitOfWork _unitOfWork;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CarBusLogLib()
        {
            _unitOfWork = new UnitOfWork();
            Mapper.CreateMap<Car, CarEntity>();
            Mapper.CreateMap<CarEntity, Car>();
        }

        public IEnumerable<CarEntity> GetUsedCarsList()
        {
            var usedCarsList = Mapper.Map<List<CarEntity>>(_unitOfWork.CarRepository.GetMany(c => c.IsNewCar == false));
            return usedCarsList;
        }

        public IEnumerable<CarEntity> GetNewCarsList()
        {
            var newCarsList = Mapper.Map<List<CarEntity>>(_unitOfWork.CarRepository.GetMany(c => c.IsNewCar == true));
            return newCarsList;
        }

        public bool CreateCar(CarEntity CarDetails)
        {
            try
            {
                var a = Mapper.Map<Car>(CarDetails);
                _unitOfWork.CarRepository.Insert(a);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateCar(int id, CarEntity UpdatedCarDetails)
        {
            try
            {
                _unitOfWork.CarRepository.Update(Mapper.Map<Car>(UpdatedCarDetails));
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool DeleteCar(int CarId,CarEntity DeleteCarDetails)
        {
            try
            {
                _unitOfWork.CarRepository.Delete(Mapper.Map<Car>(DeleteCarDetails));
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public CarEntity GetById(int CarId)
        {
            try
            {
                return Mapper.Map<CarEntity>(_unitOfWork.CarRepository.GetByID(CarId));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public bool EditCar(int CarId)
        {
            try
            {
                _unitOfWork.CarRepository.EditCar(CarId);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
    }
}
