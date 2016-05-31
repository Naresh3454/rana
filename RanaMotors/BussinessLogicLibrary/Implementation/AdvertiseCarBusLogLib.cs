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
    public class AdvertiseCarBusLogLib : IAdvertiseCarBusLogLib
    {
        private readonly UnitOfWork _unitOfWork;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AdvertiseCarBusLogLib()
        {
            _unitOfWork = new UnitOfWork();
            Mapper.CreateMap<AdvertiseCar, AdvertiseCarEntity>();
            Mapper.CreateMap<AdvertiseCarEntity, AdvertiseCar>();
        }

        public IEnumerable<AdvertiseCarEntity> GetUsedCarsList()
        {
            var usedCarsList = Mapper.Map<List<AdvertiseCarEntity>>(_unitOfWork.CarRepository.GetMany(c => c.IsNewCar == false));
            return usedCarsList;
        }

        public IEnumerable<AdvertiseCarEntity> GetNewCarsList()
        {
            var newCarsList = Mapper.Map<List<AdvertiseCarEntity>>(_unitOfWork.CarRepository.GetMany(c => c.IsNewCar == true));
            return newCarsList;
        }

        public bool CreateAdvertiseCar(AdvertiseCarEntity CarDetails)
        {
            try
            {
                var a = Mapper.Map<AdvertiseCar>(CarDetails);
                _unitOfWork.AdvertiseCarRepository.Insert(a);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateAdvertisedCar(int id, AdvertiseCarEntity UpdatedCarDetails)
        {
            try
            {
                _unitOfWork.AdvertiseCarRepository.Update(Mapper.Map<AdvertiseCar>(UpdatedCarDetails));
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool DeleteAdvertisedCar(int CarId, AdvertiseCarEntity DeleteCarDetails)
        {
            try
            {
                _unitOfWork.AdvertiseCarRepository.Delete(Mapper.Map<AdvertiseCar>(DeleteCarDetails));
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public AdvertiseCarEntity GetById(int CarId)
        {
            try
            {
                return Mapper.Map<AdvertiseCarEntity>(_unitOfWork.AdvertiseCarRepository.GetByID(CarId));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public bool EditAdvertisedCar(int CarId)
        {
            try
            {
                _unitOfWork.AdvertiseCarRepository.EditCar(CarId);
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

