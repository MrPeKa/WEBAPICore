using System.Collections.Generic;
using CoreWEBAPI.Domain.Models;

namespace CoreWEBAPI.Database.Repositories
{
    public interface IBillRepository
    {
        BillModel GetBill(int id);
        IEnumerable<BillModel> GetBills();
        BillModel AddBill(BillModel bill);
        void RemoveBill(int id);
        BillModel UpdateBill(BillModel newBill);
    }

    public interface ICompanyRepository
    {
        CompanyModel GetCompany(int id);
        IEnumerable<CompanyModel> GetCompanies();
        void AddCompany(CompanyModel company);
        void RemoveCompany(int id);
        void UpdateCompany(CompanyModel newCompany);
    }

    public interface IProductRepository
    {
        ProductModel GetProduct(int id);
        IEnumerable<ProductModel> GetProducts();
        void AddProduct(ProductModel product);
        void AddProducts(ICollection<ProductModel> products);
    }
}