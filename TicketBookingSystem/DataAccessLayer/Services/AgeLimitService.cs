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
    public class AgeLimitService : IAgeLimitService
    {
        IUnitOfWork unitOfWork;
        public AgeLimitService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<AgeLimit> AddAsync(AgeLimit item)
        {
            await unitOfWork.AgeLimitRepository.AddAsync(item);
            return item;
        }

        public async Task<AgeLimit?> DeleteAsync(int id)
        {
            AgeLimit ageLimit = await GetByIdAsync(id);
            await unitOfWork.AgeLimitRepository.DeleteAsync(ageLimit);
            return ageLimit;
        }

        public async Task<IEnumerable<AgeLimit>> GetAllAsync()
        {
            return await unitOfWork.AgeLimitRepository.ListAllAsync();
        }

        public async Task<AgeLimit?> GetByIdAsync(int id)
        {
            return await unitOfWork.AgeLimitRepository.GetByIdAsync(id);
        }

        public async Task<AgeLimit> UpdateAsync(AgeLimit item)
        {
            await unitOfWork.AgeLimitRepository.UpdateAsync(item);
            return item;
        }
    }
}
