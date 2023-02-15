using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.Domain
{
    public class BrandMedicinePrice
    {
        [Key]        
        public int BrandId { get; set; }
        public int MedicineId { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
        public Medicine Medicine { get; set; }
    }
}
