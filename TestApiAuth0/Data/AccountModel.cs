using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace TestApiAuth0.Data
{
    [Table("accounts")]
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50), Required(ErrorMessage = "AccountNumber is required")]
        public string AccountNumber { get; set; }

        [StringLength(100), Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AccountTypes AccountType { get; set; }
    }

    public enum AccountTypes {
        CASH,
        CHECK,
        SAVINGS
    }
}
