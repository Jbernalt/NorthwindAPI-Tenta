using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindApiTenta1.Data.Entities;

namespace NorthwindApiTenta1.Data
{
  public interface ISupplierRepository
  {
    Task<bool> SaveChangesAsync();

    void AddSupplier(Suppliers supplier);
    void DeleteSupplier(Suppliers supplier);
    Task<Suppliers> GetSupplierByNameAsync(string Name);
    Task<Suppliers[]> GetAllSuppliersAsync();
    Task<Suppliers> GetSupplierAsync(int SupplierID);


  }
}