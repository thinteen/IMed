using System.ComponentModel.DataAnnotations;

namespace DrugStore.Domain
{
    public class AdminAccount
    {
        [Key]
        public int AdminAccountId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
