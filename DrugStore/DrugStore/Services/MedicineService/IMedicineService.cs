using DrugStore.Domain;
using DrugStore.Dto;

namespace DrugStore.Services.MedicineService
{
    public interface IMedicineService
    {
        public int Add(MedicineDto medicineDto);
        public List<Medicine> GetAll();
        public List<PharmacyMedicine> GetAllPharmacyMedicine();
        public List<BrandMedicinePrice> GetAllBrandMedicinePrice();
        public int Update(MedicineDto medicineDto);
        public void Delete(int medicineId);
        public int AddMedicinePriceForBrand(BrandMedicinePriceDto brandMedicinePriceDto);
        public int AddResidualMedicineInPharmacy(PharmacyMedicineDto pharmacyMedicineDto);
        List<MedicinesWithPriceAndPlaceOfPurchase> GetMedicineWithPriceAndPlaceOfPurchaseById(int medicineId);
        public List<Medicine> GetMedicineByName(string medicineName);
        public List<Medicine> GetMedicineByCategory(string medicineCategory);
        public Medicine GetMedicineById(int medicineId);
        public List<Medicine> GetMedicineByNameWithCategory(string medicineCategory, string medicineName);
        public List<MedicinePrice> GetMedicineWithPriceByBrandId(int brandId);
        public int UpdateBrandMedicinePrice(BrandMedicinePriceDto brandMedicinePriceDto);
        public void DeleteBrandMedicinePrice(int medicineId, int brandId);
        public List<MedicineCount> GetPharmacyMedicinesById(int pharmacyId);
        public void DeleteMedicineFromPharmacy(int medicineId, int pharmacyId);
        public int UpdateCountOfMedicineInPharmacy(PharmacyMedicineDto pharmacyMedicineDto);
        public List<Medicine> GetPopularMedicine();
    }
}
