using DataAccessLayer.Abstractions;
using DataLayer.Abstractions;
using EntityLibrary.EventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class LocationService : ILocationService
    {
        IUnitOfWork unitOfWork;

        LocationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Location> AddAsync(Location item)
        {
            await unitOfWork.LocationRepository.AddAsync(item);
            return item;
        }

        public async Task<Location?> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item != null) await unitOfWork.LocationRepository.DeleteAsync(item);
            return item;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await unitOfWork.LocationRepository.ListAllAsync();
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await unitOfWork.LocationRepository.GetByIdAsync(id);
        }

        public async Task<Location> UpdateAsync(Location item)
        {
            await unitOfWork.LocationRepository.UpdateAsync(item);
            return item;
        }
    }
}
