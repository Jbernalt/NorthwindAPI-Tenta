using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NorthwindApiTenta1.Data.Entities;

namespace NorthwindApiTenta1.Data
{
  public class SupplierRepository : ISupplierRepository
  {
    private readonly NorthwindContext _context;

    public SupplierRepository(NorthwindContext context)
    {
      _context = context;
    }

    public void AddSupplier(Suppliers supplier)
    {
      _context.Suppliers.Add(supplier);
    }

    public void DeleteSupplier(Suppliers suppliers)
    {
      _context.Suppliers.Remove(suppliers);
    }

    public async Task<bool> SaveChangesAsync()
    {
      // Only return success if at least one row was changed
      return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<Suppliers[]> GetAllSuppliersAsync()
    {
      IQueryable<Suppliers> query = _context.Suppliers;

      // Order It
      query = query.OrderByDescending(s => s.SupplierID);

      return await query.ToArrayAsync();
    }

    public async Task<Suppliers> GetSupplierAsync(int id)
    {
      IQueryable<Suppliers> query = _context.Suppliers;

      query = query.Where(c => c.SupplierID == id);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<Suppliers> GetSupplierByNameAsync(string Name)
    {
        var supplier = _context.Suppliers.Where(s => s.CompanyName == Name);

        return await supplier.FirstOrDefaultAsync();
    }
  }
}
