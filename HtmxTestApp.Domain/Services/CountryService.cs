using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
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
            await unitOfWork.SaveChangesAsync();
            return country;
        }

        public async Task DeleteAsync(Guid id)
        {
            Country country = await unitOfWork.CountryRepository.GetByIdAsync(id);
            unitOfWork.CountryRepository.Delete(country);
        }

        public List<Country> Find(Expression<Func<Country, bool>> predicate)
        {
            IEnumerable<Country> result = unitOfWork.CountryRepository.Find(predicate);
            return result.ToList();
        }

        public List<Country> GetAll()
        {
            IEnumerable<Country> countrys = unitOfWork.CountryRepository.GetAll();
            return countrys.ToList();
        }

        public async Task<Country> GetAsync(Guid id)
        {
            return await unitOfWork.CountryRepository.GetByIdAsync(id);
        }

        public async Task<Country> UpdateAsync(Country entity)
        {
            Country country = await unitOfWork.CountryRepository.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return country;
        }
    }
}
