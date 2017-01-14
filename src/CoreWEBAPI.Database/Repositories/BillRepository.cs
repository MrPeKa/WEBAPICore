using System.Collections.Generic;
using System.Linq;
using CoreWEBAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWEBAPI.Database.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly AppDbContext _dbContext;

        public BillRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BillModel GetBill(int id)
        {
            var bill = _dbContext.Bills.Include(b => b.Company).FirstOrDefault(x => x.Id == id);
            if (bill != null)
            {
                var products = _dbContext.Products.Where(x => x.Bill.Id == bill.Id).ToList();
                bill.Products = products;
            }
            return bill;
        }

        public IEnumerable<BillModel> GetBills()
        {
            var bills = _dbContext.Bills.Include(b => b.Company).AsEnumerable().ToList();
            foreach (var bill in bills)
            {
                bill.Products = _dbContext.Products.Where(x => x.Bill.Id == bill.Id).ToList();
            }
            return bills;
        }

        public BillModel AddBill(BillModel bill)
        {
            if (bill == null) return null;

            _dbContext.Companies.Add(bill.Company);
            _dbContext.Products.AddRange(bill.Products);
            _dbContext.Bills.Add(bill);
            _dbContext.SaveChanges();
            return bill;
            ;
        }

        public void RemoveBill(int id)
        {
            var bill = GetBill(id);
            if (bill == null) return;
            var products = _dbContext.Products.Where(x => x.Bill.Id == bill.Id);
            _dbContext.Products.RemoveRange(products);
            _dbContext.Companies.Remove(bill.Company);
            _dbContext.Remove(bill);
            _dbContext.SaveChanges();
        }

        public BillModel UpdateBill(BillModel newBill)
        {
            var bill = GetBill(newBill.Id);
            if (bill == null)
                return null;
            {
                bill.Products = newBill.Products;
                bill.Company = newBill.Company;
                bill.Date = newBill.Date;
                bill.Sum = newBill.Sum;
            }

            _dbContext.Update(bill);
            _dbContext.SaveChanges();
            return newBill;
        }
    }
}