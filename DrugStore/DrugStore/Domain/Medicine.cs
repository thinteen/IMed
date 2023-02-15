using DrugStore.Dto;
using System.ComponentModel.DataAnnotations;

namespace DrugStore.Domain
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Instruction { get; set; }
        public List<PharmacyMedicine> PharmacyMedicines { get; set; }
        public List<BrandMedicinePrice> BrandMedicinePrices { get; set; }
    }
}
