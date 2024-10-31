using System.ComponentModel.DataAnnotations;

namespace OrderSystem2024.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa kategorii")]
        public string CategoryName { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
