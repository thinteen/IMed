using DrugStore.Domain;

namespace DrugStore.Dto;

public static class MedicineCountDtoExtentions
{
    public static MedicineCount ConvertToMedicineCount(this MedicineCountDto medicineCountDto)
    {
        return new MedicineCount
        {

            MedicineId = medicineCountDto.MedicineId,
            PharmacyId = medicineCountDto.PharmacyId,
            Residual = medicineCountDto.Residual,
            Name = medicineCountDto.Name
        };
    }

    public static MedicineCountDto ConvertToMedicineCountDto(this MedicineCount medicineCount)
    {
        return new MedicineCountDto
        {
            MedicineId = medicineCount.MedicineId,
            PharmacyId = medicineCount.PharmacyId,
            Residual = medicineCount.Residual,
            Name = medicineCount.Name
        };
    }
}