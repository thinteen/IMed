using DrugStore.Domain;

namespace DrugStore.Dto;

public static class PharmacyDtoExtensions
{
    public static Pharmacy ConvertToPharmacy(this PharmacyDto pharmacyDto)
    {
        return new Pharmacy
        {
            PharmacyId = pharmacyDto.PharmacyId,
            BrandId = pharmacyDto.BrandId,
            Address = pharmacyDto.Address,
            PhoneNumber = pharmacyDto.PhoneNumber,
        };
    }
    
    public static PharmacyDto ConvertToPharmacyDto(this Pharmacy pharmacy)
    {
        return new PharmacyDto
        {
            PharmacyId = pharmacy.PharmacyId,
            BrandId = pharmacy.BrandId,
            Address = pharmacy.Address,
            PhoneNumber = pharmacy.PhoneNumber,
        };
    }
}
