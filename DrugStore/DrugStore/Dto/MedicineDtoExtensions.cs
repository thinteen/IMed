using DrugStore.Domain;

namespace DrugStore.Dto;

public static class MedicineDtoExtensions
{
    public static Medicine ConvertToMedicine(this MedicineDto medicineDto)
    {
        return new Medicine
        {
            MedicineId = medicineDto.MedicineId,
            Name = medicineDto.Name,
            Category = medicineDto.Category,
            Image = medicineDto.Image,
            Instruction = medicineDto.Instruction
        };
    }
    
    public static MedicineDto ConvertToMedicineDto(this Medicine medicine)
    {
        return new MedicineDto
        {
            MedicineId = medicine.MedicineId,
            Name = medicine.Name,
            Category = medicine.Category,
            Image = medicine.Image,
            Instruction = medicine.Instruction
        };
    }
}
