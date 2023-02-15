using DrugStore.Domain;
using DrugStore.Inftrastructure;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DrugStore.Repositories.MedicineRepository
{
    public class MedicineRepository : IMedicineRepository
    {
        private DrugStoreDbContext _context;
        public MedicineRepository(DrugStoreDbContext context)
        {
            _context = context;
        }
        public int Add(Medicine medecine) 
        {
            if (_context.Medicine.Where(m => m.Name == medecine.Name).Count() >= 1)
            {
                throw new Exception($"Medicine named {medecine.Name} already exists");
            }

            _context.Medicine.Add(medecine);
            _context.SaveChanges();

            return medecine.MedicineId;
        }

        public int AddMedicinePriceForBrand(BrandMedicinePrice brandMedicinePrice)
        {
            if (_context.Brand.Where(m => m.BrandId == brandMedicinePrice.BrandId).Count() == 0)
            {
                throw new Exception($"Brand with {brandMedicinePrice.BrandId} id not found");
            }

            if (_context.Medicine.Where(m => m.MedicineId == brandMedicinePrice.MedicineId).Count() == 0)
            {
                throw new Exception($"Medicine with {brandMedicinePrice.MedicineId} id not found");
            }

            List<BrandMedicinePrice> brands = _context.BrandMedicinePrice.Where(b => b.BrandId == brandMedicinePrice.BrandId).ToList();

            if (brands.Where(m => m.MedicineId == brandMedicinePrice.MedicineId).Count() >= 1)
            {
                throw new Exception($"Medicine with {brandMedicinePrice.MedicineId} id already exists in Brand with {brandMedicinePrice.BrandId} id");
            }

            _context.BrandMedicinePrice.Add(brandMedicinePrice);
            _context.SaveChanges();

            return brandMedicinePrice.BrandId;
        }
        public List<BrandMedicinePrice> GetAllBrandMedicinePrice() 
        {
            return _context.BrandMedicinePrice.ToList();
        }

        public int AddResidualMedicineInPharmacy(PharmacyMedicine pharmacyMedicine)
        {
            if (_context.Pharmacy.Where(m => m.PharmacyId == pharmacyMedicine.PharmacyId).Count() == 0)
            {
                throw new Exception($"Pharmacy with {pharmacyMedicine.PharmacyId} id not found");
            }

            if (_context.Medicine.Where(m => m.MedicineId == pharmacyMedicine.MedicineId).Count() == 0)
            {
                throw new Exception($"Medicine with {pharmacyMedicine.MedicineId} id not found");
            }

            List<PharmacyMedicine> pharmacies = _context.PharmacyMedicine.Where(p => p.PharmacyId == pharmacyMedicine.PharmacyId).ToList();

            if (pharmacies.Where(m => m.MedicineId == pharmacyMedicine.MedicineId).Count() >= 1)
            {
                throw new Exception($"Medicine with {pharmacyMedicine.MedicineId} id already exists in Brand with {pharmacyMedicine.PharmacyId} id");
            }


            _context.PharmacyMedicine.Add(pharmacyMedicine);
            _context.SaveChanges();

            return pharmacyMedicine.PharmacyId;
        }

        public List<PharmacyMedicine> GetAllPharmacyMedicine() 
        {
            return _context.PharmacyMedicine.ToList();
        }

        public List<Medicine> GetMedicineByName(string medicineName)
        {
            return _context.Medicine
                .Where(m => EF.Functions.Like(m.Name, $"%{medicineName}%")).ToList();
        }

        public List<Medicine> GetMedicineByNameWithCategory(string medicineCategory, string medicineName)
        {
            List<Medicine> medicines = _context.Medicine.Where(m => m.Category == medicineCategory).ToList();

            return medicines.Where(m => m.Name.Contains(medicineName)).ToList();
        }

        public Medicine GetMedicineById(int medicineId)
        {
            return _context.Medicine
                .FirstOrDefault((m => m.MedicineId == medicineId));
        }

        public List<Medicine> GetMedicineByCategory(string medicineCategory)
        {
            return _context.Medicine
                .Where(m => m.Category == medicineCategory).ToList();
        }

        public Medicine GetMedicineWithPriceAndPlaceOfPurchaseById(int medicineId)
        {
            return _context.Medicine
                .Where(m => m.MedicineId == medicineId)
                .Include(item => item.BrandMedicinePrices)
                .Include(item => item.PharmacyMedicines).ToList().First();
        }

        public List<MedicinePrice> GetMedicineWithPriceByBrandId(int brandId)
        {
            return _context.BrandMedicinePrice
                .Where(item => item.BrandId == brandId)
                .Include(item => item.Medicine)
                .Select(medicinePrice => new MedicinePrice
                {
                    MedicineId = medicinePrice.Medicine.MedicineId,
                    MedicineName = medicinePrice.Medicine.Name,
                    Category = medicinePrice.Medicine.Category,
                    Price = medicinePrice.Price
                }).ToList();
        }

        public List<Medicine> GetAll() 
        {
            return _context.Medicine.ToList();
        }

        public Medicine GetById(int medicineId)
        {
            return _context.Medicine.Find(medicineId);
        }

        public int Update(Medicine medicine) 
        {
            Medicine medicineEntity = GetById(medicine.MedicineId);

            medicineEntity.Name = medicine.Name;
            medicineEntity.Category = medicine.Category;
            medicineEntity.Image = medicine.Image;
            medicineEntity.Instruction = medicine.Instruction;

            _context.SaveChanges();

            return medicine.MedicineId;
        }

        public int UpdateBrandMedicinePrice(BrandMedicinePrice brandMedicinePrice)
        {
            List<BrandMedicinePrice> medicinePrices = _context.BrandMedicinePrice.Where(m => m.MedicineId == brandMedicinePrice.MedicineId).ToList();

            BrandMedicinePrice brandMedicine = medicinePrices.Find(m => m.BrandId == brandMedicinePrice.BrandId);

            brandMedicine.Price = brandMedicinePrice.Price;

            _context.SaveChanges();

            return brandMedicine.MedicineId;
        }

        public int UpdateCountOfMedicineInPharmacy(PharmacyMedicine pharmacyMedicine) 
        {
            List<PharmacyMedicine> pharmacyMedicines = _context.PharmacyMedicine.Where(m => m.PharmacyId == pharmacyMedicine.PharmacyId).ToList();

            PharmacyMedicine pM = pharmacyMedicines.Find(m => m.MedicineId == pharmacyMedicine.MedicineId);

            pM.Residual = pharmacyMedicine.Residual;

            _context.SaveChanges();

            return pM.MedicineId;
        }

        public void Delete(Medicine medecine) 
        {
            _context.Medicine.Remove(medecine);
            _context.SaveChanges();
        }

        public Medicine? GetByName(string name)
        {
            return _context.Medicine.FirstOrDefault(item => item.Name == name);
        }

        public void DeleteBrandMedicinePrice(int medicineId, int brandId)
        {
            List<BrandMedicinePrice> medicinePrices = _context.BrandMedicinePrice.Where(m => m.MedicineId == medicineId).ToList();

            BrandMedicinePrice brandMedicine = medicinePrices.Find(m => m.BrandId == brandId);

            _context.BrandMedicinePrice.Remove(brandMedicine);

            _context.SaveChanges();
        }

        public void DeleteMedicineFromPharmacy(int medicineId, int pharmacyId)
        {
            List<PharmacyMedicine> pharmacyMedicines = _context.PharmacyMedicine.Where(pm => pm.PharmacyId == pharmacyId).ToList();

            PharmacyMedicine pharmacyMedicine = pharmacyMedicines.Find(m => m.MedicineId == medicineId);

            _context.PharmacyMedicine.Remove(pharmacyMedicine);

            _context.SaveChanges();
        }

        public List<MedicineCount> GetPharmacyMedicinesById(int pharmacyId)
        {
            return _context.PharmacyMedicine
                .Where(pm => pm.PharmacyId == pharmacyId)
                .Include(m => m.Medicine)
                .Select(medicineCount => new MedicineCount
                {
                    MedicineId = medicineCount.MedicineId,
                    PharmacyId = medicineCount.PharmacyId,
                    Residual = medicineCount.Residual,
                    Name = medicineCount.Medicine.Name
                }).ToList();
        }

        public List<Medicine> GetPopularMedicine()
        {
            var groupList = _context.PharmacyMedicine
                .GroupBy(p => p.MedicineId)
                .Select(pm => new { pm.Key, Count = pm.Count() }).ToList();

            groupList.OrderBy(x => x.Count);

            groupList.Sort((u1, u2) => u2.Count.CompareTo(u1.Count));

            List<Medicine> medicines = new List<Medicine>();

            foreach (var group in groupList)
            {
                medicines.Add(_context.Medicine.Where(m => m.MedicineId == group.Key).First());
            }

            return medicines;
        }
    }
}