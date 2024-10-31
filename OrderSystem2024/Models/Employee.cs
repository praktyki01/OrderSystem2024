using System.ComponentModel.DataAnnotations;

namespace OrderSystem2024.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Imie")]
        public string FirstName { get; set; }
        [Display(Name = "Data urodzenia, godzina")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Zdjęcie")]
        public string Photo { get; set; }
        [Display(Name = "Notatka")]
        public string Notes { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
