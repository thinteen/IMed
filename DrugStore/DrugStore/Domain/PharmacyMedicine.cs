using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.Domain
{
    public class PharmacyMedicine
    {
        [Key]
        public int PharmacyId { get; set; }
        public int MedicineId { get; set; }
        public int Residual { get; set; }
        public Medicine Medicine { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
