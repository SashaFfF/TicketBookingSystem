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
    public class CategoryService : ICategoryService
    {
        IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Category> AddAsync(Category item)
        {
            await unitOfWork.CategoryRepository.AddAsync(item);
            return item;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            Category category = await GetByIdAsync(id);
            await unitOfWork.CategoryRepository.DeleteAsync(category);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await unitOfWork.CategoryRepository.ListAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await unitOfWork.CategoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> UpdateAsync(Category item)
        {
            await unitOfWork.CategoryRepository.UpdateAsync(item);
            return item;
        }
    }
}
