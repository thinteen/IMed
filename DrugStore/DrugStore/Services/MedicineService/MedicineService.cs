using DrugStore.Domain;
using DrugStore.Dto;
using DrugStore.Repositories.BrandRepository;
using DrugStore.Repositories.MedicineRepository;
using DrugStore.Repositories.PharmacyRepository;

namespace DrugStore.Services.MedicineService
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly IBrandRepository _brandRepository;

        public MedicineService(
            IMedicineRepository medicineRepository,
            IPharmacyRepository pharmacyRepository,
            IBrandRepository brandRepository)
        {
            _medicineRepository = medicineRepository;
            _pharmacyRepository = pharmacyRepository;
            _brandRepository = brandRepository;
        }

        public int Add(MedicineDto medicineDto)
        {
            if (medicineDto == null)
            {
                throw new Exception($"{nameof(Medicine)} not found");
            }

            Medicine medicineEntity = medicineDto.ConvertToMedicine();
        
            return _medicineRepository.Add(medicineEntity);
        }

        public int AddMedicinePriceForBrand(BrandMedicinePriceDto brandMedicinePriceDto)
        {
            if(brandMedicinePriceDto == null)
            {
                throw new Exception($"{nameof(BrandMedicinePriceDto)} not found");
            }
        
            BrandMedicinePrice brandMedicinePriceEntity = brandMedicinePriceDto.ConvertToBrandMedicinePrice();
        
            return _medicineRepository.AddMedicinePriceForBrand(brandMedicinePriceEntity);
        }

        public List<BrandMedicinePrice> GetAllBrandMedicinePrice()
        {
            return _medicineRepository.GetAllBrandMedicinePrice();
        }

        public int AddResidualMedicineInPharmacy(PharmacyMedicineDto pharmacyMedicineDto)
        {
            if (pharmacyMedicineDto == null)
            {
                throw new Exception($"{nameof(PharmacyMedicineDto)} not found");
            }
        
            PharmacyMedicine pharmacyMedicineEntity = pharmacyMedicineDto.ConvertToPharmacyMedicine();
        
            return _medicineRepository.AddResidualMedicineInPharmacy(pharmacyMedicineEntity);
        }

        public List<PharmacyMedicine> GetAllPharmacyMedicine()
        {
            return _medicineRepository.GetAllPharmacyMedicine();
        }

        public List<Medicine> GetMedicineByName(string medicineName)
        {
            if (medicineName == null)
            {
                throw new Exception("Medicine name not writen");
            }

            return _medicineRepository.GetMedicineByName(medicineName);
        }

        public List<MedicinePrice> GetMedicineWithPriceByBrandId(int brandId)
        {
            if (brandId == null)
            {
                throw new Exception("Brand with this id not found");
            }

            return _medicineRepository.GetMedicineWithPriceByBrandId(brandId);
        }

        public Medicine GetMedicineById(int medicineId)
        {
            if (medicineId == null)
            {
                throw new Exception("Medicine id not found");
            }

            return _medicineRepository.GetMedicineById(medicineId);
        }
        public List<Medicine> GetMedicineByCategory(string medicineCategory)
        {
            if (medicineCategory == null)
            {
                throw new Exception("This category does not exist");
            }

            return _medicineRepository.GetMedicineByCategory(medicineCategory);
        }

        public List<MedicineCount> GetPharmacyMedicinesById(int pharmacyId)
        {
            if (pharmacyId == null)
            {
                throw new Exception("PharmacyMedicine id not found");
            }

            return _medicineRepository.GetPharmacyMedicinesById(pharmacyId);
        }

        public List<Medicine> GetMedicineByNameWithCategory(string medicineCategory, string medicineName)
        {
            if (medicineCategory == null || medicineName == null)
            {
                throw new Exception("This pharmacy does not exist");
            }

            return _medicineRepository.GetMedicineByNameWithCategory(medicineCategory, medicineName);
        }

        public List<MedicinesWithPriceAndPlaceOfPurchase> GetMedicineWithPriceAndPlaceOfPurchaseById(int medicineId)
        {
            Medicine medicine = _medicineRepository.GetMedicineWithPriceAndPlaceOfPurchaseById(medicineId);

            List<int> pharmacyIds = medicine.PharmacyMedicines
                .Select(item => item.PharmacyId)
                .Distinct()
                .ToList();

            var result = new List<MedicinesWithPriceAndPlaceOfPurchase>();

            foreach (var brandMedicine in medicine.BrandMedicinePrices)
            {
                var currentBrand = _brandRepository.GetById(brandMedicine.BrandId);
                foreach (var pharmacyMedicines in medicine.PharmacyMedicines)
                {
                    var currentPharmancy = _pharmacyRepository.GetById(pharmacyMedicines.PharmacyId);
                    if(currentPharmancy.BrandId != currentBrand.BrandId)
                    {
                        continue;
                    }
                    var medicinesWithPriceAndPlaceOfPurchase = new MedicinesWithPriceAndPlaceOfPurchase
                    {
                        MedicineName = medicine.Name,
                        MedicinePrice = brandMedicine.Price,
                        MedicineCategory = medicine.Category,
                        MedicineInstruction = medicine.Instruction,
                        MedicineImage = medicine.Image,
                        PharmacyName = currentBrand.Name,
                        PharmacyAddress = currentPharmancy.Address,
                        MedicineResidual = pharmacyMedicines.Residual,
                        PharmacyPhoneNumber = currentPharmancy.PhoneNumber,
                    };
                    result.Add(medicinesWithPriceAndPlaceOfPurchase);
                }
            }

            result.Sort(delegate (MedicinesWithPriceAndPlaceOfPurchase item1, MedicinesWithPriceAndPlaceOfPurchase item2) {
                return item1.MedicinePrice.CompareTo(item2.MedicinePrice);
            });

            return result;
        }

        public List<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }
        public int Update(MedicineDto medicineDto)
        {
            if (medicineDto == null)
            {
                throw new Exception($"{nameof(medicineDto)} not found");
            }
        
            if (_medicineRepository.GetById(medicineDto.MedicineId) != null)
            {
                return _medicineRepository.Update(medicineDto.ConvertToMedicine());
            }
            else
            {
                throw new Exception($"{nameof(medicineDto)} not found with id {medicineDto.MedicineId}");
            }
        }

        public int UpdateBrandMedicinePrice(BrandMedicinePriceDto brandMedicinePriceDto)
        {
            if (brandMedicinePriceDto == null)
            {
                throw new Exception($"{nameof(brandMedicinePriceDto)} not found");
            }

            if (_medicineRepository.GetById(brandMedicinePriceDto.MedicineId) != null)
            {
                return _medicineRepository.UpdateBrandMedicinePrice(brandMedicinePriceDto.ConvertToBrandMedicinePrice());
            }
            else
            {
                throw new Exception($"{nameof(brandMedicinePriceDto)} not found with id {brandMedicinePriceDto.MedicineId}");
            }
        }

        public int UpdateCountOfMedicineInPharmacy(PharmacyMedicineDto pharmacyMedicineDto)
        {
            if (pharmacyMedicineDto == null)
            {
                throw new Exception($"{nameof(pharmacyMedicineDto)} not found");
            }

            if (_medicineRepository.GetById(pharmacyMedicineDto.MedicineId) != null)
            {
                return _medicineRepository.UpdateCountOfMedicineInPharmacy(pharmacyMedicineDto.ConvertToPharmacyMedicine());
            }
            else
            {
                throw new Exception($"{nameof(pharmacyMedicineDto)} not found with id {pharmacyMedicineDto.MedicineId}");
            }
        }

        public void Delete(int medicineId)
        {
            Medicine medicine = _medicineRepository.GetById(medicineId);
        
            if (medicine == null)
            {
                throw new Exception($"{nameof(Medicine)} not found, Id - {medicineId}");
            }
        
            _medicineRepository.Delete(medicine);
        }

        public void DeleteBrandMedicinePrice(int medicineId, int brandId)
        {
            if (medicineId == null)
            {
                throw new Exception($"MedicineId - {medicineId} not found");
            }

            if (brandId == null)
            {
                throw new Exception($"BrandId - {brandId} not found");
            }

            _medicineRepository.DeleteBrandMedicinePrice(medicineId, brandId);
        }

        public void DeleteMedicineFromPharmacy(int medicineId, int pharmacyId)
        {
            if (medicineId == null)
            {
                throw new Exception($"MedicineId - {medicineId} not found");
            }

            if (pharmacyId == null)
            {
                throw new Exception($"PharmacyId - {pharmacyId} not found");
            }

            _medicineRepository.DeleteMedicineFromPharmacy(medicineId, pharmacyId);
        }

        public List<Medicine> GetPopularMedicine()
        {
            return _medicineRepository.GetPopularMedicine();
        }
    }
}