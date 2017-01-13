using System;
using System.Collections.Generic;

namespace CoreWEBAPI.Domain.Models
{
    public interface IBill
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        CompanyModel Company { get; set; }
        ICollection<ProductModel> Products { get; set; }
        double Sum { get; set; }
    }

    public interface ICompany
    {
        int Id { get; set; }
        string Name { get; set; }
        ICollection<BillModel> Bills { get; set; }
    }

    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        int Quantity { get; set; }
        double Prize { get; set; }
        BillModel Bill { get; set; }
    }
}