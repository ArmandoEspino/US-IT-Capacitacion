using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankAPI.Data.BankModels
{
    public partial class Client
    {
        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [MaxLength(40, ErrorMessage = "El numero debe ser menor a 40 caracteres")]
        public string PhoneNumber { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; }
        public DateTime RegDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
