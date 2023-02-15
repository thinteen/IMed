using DrugStore.Domain;
using DrugStore.Inftrastructure;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.Repositories.PharmacyRepository
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private DrugStoreDbContext _context;

        public PharmacyRepository(DrugStoreDbContext context)
        {
            _context = context;
        }

        public List<BrandPharmacy> GetPharmaciesByBrandId(int brandId)
        {
            return _context.Pharmacy.Where(item => item.BrandId == brandId)
                .Include(b => b.Brand)
                .Select(pharmacy => new BrandPharmacy
                {
                    PharmacyId = pharmacy.PharmacyId,
                    BrandId = pharmacy.BrandId,
                    PharmacyName = pharmacy.Brand.Name,
                    Address = pharmacy.Address,
                    PhoneNumber = pharmacy.PhoneNumber,
                }).ToList();
        }

        public Pharmacy GetPharmacyById(int pharmacyId)
        {
            return _context.Pharmacy.FirstOrDefault(p => p.PharmacyId == pharmacyId);
        }

        public int Add(Pharmacy pharmacy) 
        {
            if (_context.Brand.Where(m => m.BrandId == pharmacy.BrandId).Count() == 0)
            {
                throw new Exception($"Pharmacy with {pharmacy.BrandId} id not found");
            }

            _context.Pharmacy.Add(pharmacy);
            _context.SaveChanges();

            return pharmacy.PharmacyId;
        }
        public List<Pharmacy> GetAll() 
        {
            return _context.Pharmacy.ToList();
        }

        public Pharmacy GetById(int pharmacyId)
        {
            return _context.Pharmacy.Find(pharmacyId);
        }
        public int Update(Pharmacy pharmacy) 
        {
            Pharmacy pharmacyEntity = GetById(pharmacy.PharmacyId);

            pharmacyEntity.BrandId = pharmacy.BrandId;
            pharmacyEntity.Address = pharmacy.Address;
            pharmacyEntity.PhoneNumber = pharmacy.PhoneNumber;

            _context.SaveChanges();

            return pharmacy.PharmacyId;
        }
        public void Delete(Pharmacy pharmacy) 
        {
            _context.Pharmacy.Remove(pharmacy);
            _context.SaveChanges();
        }
    }
}
