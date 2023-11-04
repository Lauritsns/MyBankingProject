using MyBankingProject.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyBankingProject.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(10,11)]
        public string CPR { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "This is not a Email")]
        public string Email { get; set; }

        public Customer() { }

        public Customer(int id, string name, string cpr, string address, string city, string email)
        {
            this.Id = id;
            this.Name = name;
            this.CPR = cpr;
            this.Address = address;
            this.City = city;
            this.Email = email;
        }
    }
}
