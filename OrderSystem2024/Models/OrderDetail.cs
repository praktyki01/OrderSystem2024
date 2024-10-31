using System.ComponentModel.DataAnnotations;

namespace OrderSystem2024.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        
        public int OrderId { get; set; }
        [Display(Name = "Zamówienie")]
        public Order? Order { get; set; } = null!;

        public int ProductId { get; set; }
        [Display(Name = "Produkt")]
        public Product? Product { get; set; } = null!;
    }
}
