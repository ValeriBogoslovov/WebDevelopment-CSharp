
namespace CarDealerApp.Services
{
    using CarDealer.Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class SuppliersService
    {
        public IEnumerable<SuppliersViewModel> GetSuppliers(string typeOfSupplier)
        {
            IEnumerable<SuppliersViewModel> suppliers = null;
            using (var context = new CarDealerContext())
            {
                if (typeOfSupplier == "local")
                {
                    suppliers = context.Suppliers
                        .Where(s => s.IsImporter == false)
                        .Select(s => new SuppliersViewModel()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            NumberOfParts = context.Parts.Where(p => p.Supplier.Id == s.Id).Count()
                        }).ToList();
                }
                else
                {
                    suppliers = context.Suppliers
                        .Where(s => s.IsImporter == true)
                        .Select(s => new SuppliersViewModel()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            NumberOfParts = context.Parts.Where(p => p.Supplier.Id == s.Id).Count()
                        }).ToList();
                }
            }
            return suppliers;
        }
    }
}