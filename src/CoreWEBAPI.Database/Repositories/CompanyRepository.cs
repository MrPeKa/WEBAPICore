using System.Collections.Generic;
using System.Linq;
using CoreWEBAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWEBAPI.Database.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _dbContext;

        public CompanyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CompanyModel GetCompany(int id)
        {
            return _dbContext.Companies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CompanyModel> GetCompanies()
        {
            return _dbContext.Companies.AsEnumerable();
        }

        public void AddCompany(CompanyModel company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
        }

        public void RemoveCompany(int id)
        {
            var company = _dbContext.Companies.FirstOrDefault(x => x.Id == id);
            if (company == null) return;

            _dbContext.Remove(company);
            _dbContext.SaveChanges();
        }

        public void UpdateCompany(CompanyModel newCompany)
        {
            var company = _dbContext.Bills.FirstOrDefault(x => x.Id == newCompany.Id);
            if (company == null) return;

            _dbContext.Attach(newCompany);
            _dbContext.Entry(newCompany).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}