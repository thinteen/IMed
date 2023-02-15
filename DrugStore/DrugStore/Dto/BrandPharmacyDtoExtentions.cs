using DrugStore.Domain;

namespace DrugStore.Dto;

public static class BrandPharmacyDtoExtentions
{
    public static BrandPharmacy ConvertToBrandPharmacy(this BrandPharmacyDto brandPharmacyDto)
    {
        return new BrandPharmacy
        {
            PharmacyId = brandPharmacyDto.PharmacyId,
            BrandId = brandPharmacyDto.BrandId,
            PharmacyName = brandPharmacyDto.PharmacyName,
            PhoneNumber = brandPharmacyDto.PhoneNumber,
            Address = brandPharmacyDto.Address,
        };
    }

    public static BrandPharmacyDto ConvertToBrandPharmacyDto(this BrandPharmacy brandPharmacy)
    {
        return new BrandPharmacyDto
        {
            PharmacyId = brandPharmacy.PharmacyId,
            BrandId = brandPharmacy.BrandId,
            PharmacyName = brandPharmacy.PharmacyName,
            PhoneNumber = brandPharmacy.PhoneNumber,
            Address = brandPharmacy.Address,
        };
    }
}
