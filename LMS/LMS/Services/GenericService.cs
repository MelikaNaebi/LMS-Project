using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Interfaces;

namespace LMS.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<T>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.Repository<T>().GetAllAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _unitOfWork.Repository<T>().AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _unitOfWork.Repository<T>().UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Repository<T>().GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.Repository<T>().DeleteAsync(id);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
