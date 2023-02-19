using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
            Country country = await unitOfWork.CountryRepository.Add(entity);
            await unitOfWork.SaveChanges();
            return country;
        }

        public async Task DeleteAsync(Guid id)
        {
            Country country = await unitOfWork.CountryRepository.Get(id);
            await unitOfWork.CountryRepository.Delete(country);
        }

        public async Task<List<Country>> FindAsync(Expression<Func<Country, bool>> predicate)
        {
            IEnumerable<Country> result = await unitOfWork.CountryRepository.Find(predicate);
            return result.ToList();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            IEnumerable<Country> countrys = await unitOfWork.CountryRepository.All();
            return countrys.ToList();
        }

        public async Task<Country> GetAsync(Guid id)
        {
            return await unitOfWork.CountryRepository.Get(id);
        }

        public async Task<Country> UpdateAsync(Country entity)
        {
            Country country = await unitOfWork.CountryRepository.Update(entity);
            await unitOfWork.SaveChanges();
            return country;
        }
    }
}
