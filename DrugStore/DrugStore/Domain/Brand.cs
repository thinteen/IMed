using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.Domain
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<Pharmacy> Pharmacies { get; set; }
        public List<BrandMedicinePrice> BrandMedicinePrices { get; set; }
    }
}
