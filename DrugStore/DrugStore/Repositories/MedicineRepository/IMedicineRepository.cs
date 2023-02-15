using DrugStore.Domain;

namespace DrugStore.Repositories.MedicineRepository
{
    public interface IMedicineRepository
    {
        public int Add(Medicine medecine);
        public List<Medicine> GetAll();
        public List<PharmacyMedicine> GetAllPharmacyMedicine();
        public List<BrandMedicinePrice> GetAllBrandMedicinePrice();
        public Medicine GetById(int medicineId);
        public int Update(Medicine medicine);
        public void Delete(Medicine medecine);
        public Medicine? GetByName(string name);
        public int AddMedicinePriceForBrand(BrandMedicinePrice brandMedicinePrice);
        public int AddResidualMedicineInPharmacy(PharmacyMedicine pharmacyMedicine);
        public Medicine GetMedicineWithPriceAndPlaceOfPurchaseById(int medicineId);
        public List<Medicine> GetMedicineByName(string medicineName);
        public List<Medicine> GetMedicineByCategory(string medicineCategory);
        public Medicine GetMedicineById(int medicineId);
        public List<Medicine> GetMedicineByNameWithCategory(string medicineCategory, string medicineName);
        public List<MedicinePrice> GetMedicineWithPriceByBrandId(int brandId);
        public int UpdateBrandMedicinePrice(BrandMedicinePrice brandMedicinePrice);
        public void DeleteBrandMedicinePrice(int medicineId, int brandId);
        public List<MedicineCount> GetPharmacyMedicinesById(int pharmacyId);
        public void DeleteMedicineFromPharmacy(int medicineId, int pharmacyId);
        public int UpdateCountOfMedicineInPharmacy(PharmacyMedicine pharmacyMedicine);
        public List<Medicine> GetPopularMedicine();
    }
}
