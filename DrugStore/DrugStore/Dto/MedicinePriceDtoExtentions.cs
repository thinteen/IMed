using DrugStore.Domain;

namespace DrugStore.Dto;

public static class MedicinePriceDtoExtentions
{
    public static MedicinePrice ConvertToMedicinePrice(this MedicinePriceDto medicinePriceDto)
    {
        return new MedicinePrice
        {

            MedicineId = medicinePriceDto.MedicineId,
            MedicineName = medicinePriceDto.MedicineName,
            Category = medicinePriceDto.Category,
            Price = medicinePriceDto.Price,
        };
    }

    public static MedicinePriceDto ConvertToMedicinePriceDto(this MedicinePrice medicinePrice)
    {
        return new MedicinePriceDto
        {
            MedicineId = medicinePrice.MedicineId,
            MedicineName = medicinePrice.MedicineName,
            Category = medicinePrice.Category,
            Price = medicinePrice.Price,
        };
    }
}