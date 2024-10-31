using System.ComponentModel.DataAnnotations;

namespace OrderSystem2024.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa produktu")]
        public string ProductName { get; set; }
        [Display(Name = "Ilość")]
        public string Unit { get; set; }
        [Display(Name = "Kwota")]
        public decimal Price { get; set; }

        public int SupplierId { get; set; }
        [Display(Name = "Dostawca")]
        public Supplier? Supplier { get; set; } = null!;

        public int CategoryId { get; set; }
        [Display(Name = "Kategoria")]
        public Category? Category { get; set; } = null!;

        public ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
    }
}
