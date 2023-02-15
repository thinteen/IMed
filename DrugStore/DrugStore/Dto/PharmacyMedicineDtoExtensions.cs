using DrugStore.Domain;

namespace DrugStore.Dto;

public static class PharmacyMedicineDtoExtensions
{
    public static PharmacyMedicine ConvertToPharmacyMedicine(this PharmacyMedicineDto pharmacyMedicineDto)
    {
        return new PharmacyMedicine
        {
            PharmacyId = pharmacyMedicineDto.PharmacyId,
            MedicineId = pharmacyMedicineDto.MedicineId,
            Residual = pharmacyMedicineDto.Residual,
        };
    }
    
    public static PharmacyMedicineDto ConvertToPharmacyMedicineDto(this PharmacyMedicine pharmacyMedicine)
    {
        return new PharmacyMedicineDto
        {
            PharmacyId = pharmacyMedicine.PharmacyId,
            MedicineId = pharmacyMedicine.MedicineId,
            Residual = pharmacyMedicine.Residual,
        };
    }
}
