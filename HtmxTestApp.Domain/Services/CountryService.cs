using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HtmxTestApp.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork unitOfWork;
        public CountryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Country> AddAsync(Country entity)
        {
            Country country = await unitOfWork.CountryRepository.AddAsync(entity);
            return country;
        }

        public async Task DeleteAsync(Guid id)
        {
            Country country = await unitOfWork.CountryRepository.GetByIdAsync(id);
            await unitOfWork.CountryRepository.DeleteAsync(country);
        }

        public async Task<List<Country>> FindAsync(Expression<Func<Country, bool>> predicate)
        {
            IQueryable<Country> result = unitOfWork.CountryRepository.Find(predicate);
            return await result.ToListAsync();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            IQueryable<Country> countrys = unitOfWork.CountryRepository.GetAll();
            return await countrys.ToListAsync();
        }

        public async Task<Country> GetAsync(Guid id)
        {
            return await unitOfWork.CountryRepository.GetByIdAsync(id);
        }

        public async Task<Country> UpdateAsync(Country entity)
        {
            Country country = await unitOfWork.CountryRepository.UpdateAsync(entity);
            return country;
        }
    }
}
