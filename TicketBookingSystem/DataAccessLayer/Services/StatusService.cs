using DataAccessLayer.Abstractions;
using DataLayer.Abstractions;
using EntityLibrary.TicketClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class StatusService : IStatusService
    {
        IUnitOfWork unitOfWork;
        public StatusService(IUnitOfWork unitOfWork) 
        { 
            this.unitOfWork = unitOfWork;
        }
        public async Task<Status> AddAsync(Status item)
        {
            await unitOfWork.StatusRepository.AddAsync(item);
            return item;
        }

        public async Task<Status?> DeleteAsync(int id)
        {
            var st = await GetByIdAsync(id);
            await unitOfWork.StatusRepository.DeleteAsync(st);
            return st;
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await unitOfWork.StatusRepository.ListAllAsync();
        }

        public async Task<Status?> GetByIdAsync(int id)
        {
            return await unitOfWork.StatusRepository.GetByIdAsync(id);
        }

        public async Task<Status> UpdateAsync(Status item)
        {
            await unitOfWork.StatusRepository.UpdateAsync(item);
            return item;
        }
    }
}
