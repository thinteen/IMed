using DrugStore.Domain;

namespace DrugStore.Dto;

public static class BrandMedicinePriceDtoExtensions
{
    public static BrandMedicinePrice ConvertToBrandMedicinePrice(this BrandMedicinePriceDto brandMedicinePriceDto)
    {
        return new BrandMedicinePrice
        {
            BrandId = brandMedicinePriceDto.BrandId,
            MedicineId = brandMedicinePriceDto.MedicineId,
            Price = brandMedicinePriceDto.Price,
        };
    }
    
    public static BrandMedicinePriceDto ConvertToBrandMedicinePriceDto(this BrandMedicinePrice brandMedicinePrice)
    {
        return new BrandMedicinePriceDto
        {
            BrandId = brandMedicinePrice.BrandId,
            MedicineId = brandMedicinePrice.MedicineId,
            Price = brandMedicinePrice.Price,
        };
    }
}
