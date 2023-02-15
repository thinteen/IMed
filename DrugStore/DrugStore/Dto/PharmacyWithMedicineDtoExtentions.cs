using DrugStore.Domain;

namespace DrugStore.Dto;

public static class PharmacyWithMedicineDtoExtentions
{
    public static PharmacyWithMedicine ConvertToPharmacyWithMedicine(this PharmacyWithMedicineDto pharmacyWithMedicineDto)
    {
        return new PharmacyWithMedicine
        {
            PharmacyName = pharmacyWithMedicineDto.PharmacyName,
        };
    }

    public static PharmacyWithMedicineDto ConvertToPharmacyWithMedicineDto(this PharmacyWithMedicine pharmacyWithMedicine)
    {
        return new PharmacyWithMedicineDto
        {
            PharmacyName = pharmacyWithMedicine.PharmacyName,
        };
    }
}
