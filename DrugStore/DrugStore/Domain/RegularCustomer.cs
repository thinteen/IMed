using System.ComponentModel.DataAnnotations;

namespace DrugStore.Domain
{
    public class RegularCustomer
    {
        [Key]
        public int RegularCustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int BrandId { get; set; }
        public string CardNumber { get; set; }
        public int AccumulatedPoints { get; set; }
    }
}
