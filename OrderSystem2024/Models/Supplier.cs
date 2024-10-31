using System.ComponentModel.DataAnnotations;

namespace OrderSystem2024.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa dostawcy")]
        public string SupplierName { get; set; }
        [Display(Name = "Kontakt")]
        public string ContactName { get; set;}
        [Display(Name = "Adres")]
        public string Address { get; set;}
        [Display(Name = "Miasto")]
        public string City { get; set;}
        [Display(Name = "Kodpocztowy")]
        public string PostalCode { get; set;}
        [Display(Name = "Kraj")]
        public string Country { get; set;}
        [Display(Name = "Numer telefonu")]
        public string Phone { get; set;}

        public ICollection<Product> Products { get; } = new List<Product>();
    
    }
}
