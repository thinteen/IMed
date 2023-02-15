using System.ComponentModel.DataAnnotations;

namespace DrugStore.Domain
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyId { get; set; }
        public int BrandId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<PharmacyMedicine> PharmacyMedicines { get; set; }
        public Brand Brand { get; set; }
    }
}
