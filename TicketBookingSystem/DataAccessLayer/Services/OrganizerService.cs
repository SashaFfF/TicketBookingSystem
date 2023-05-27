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
    public class OrganizerService : IOrganizerService
    {
        IUnitOfWork unitOfWork;
        public OrganizerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Organizer> AddAsync(Organizer item)
        {
            await unitOfWork.OrganizerRepository.AddAsync(item);
            return item;
        }

        public async Task<Organizer?> DeleteAsync(int id)
        {
            Organizer org = await GetByIdAsync(id);
            await unitOfWork.OrganizerRepository.DeleteAsync(org);
            return org;
        }

        public async Task<IEnumerable<Organizer>> GetAllAsync()
        {
            return await unitOfWork.OrganizerRepository.ListAllAsync();
        }

        public async Task<Organizer?> GetByIdAsync(int id)
        {
            return await unitOfWork.OrganizerRepository.GetByIdAsync(id);  
        }

        public async Task<Organizer> UpdateAsync(Organizer item)
        {
            await unitOfWork.OrganizerRepository.UpdateAsync(item);
            return item;
        }
    }
}
