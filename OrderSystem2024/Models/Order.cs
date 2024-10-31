using System.ComponentModel.DataAnnotations;

namespace OrderSystem2024.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Data zamówienia")]
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "Klient")]
        public Customer? Customer { get; set; } = null!;

        public int EmployeeId { get; set; }
        [Display(Name = "Pracownik")]
        public Employee? Employee { get; set; } = null!;
        

        public int ShipperId { get; set; }
        [Display(Name = "Kurier")]
        public Shipper? Shipper { get; set; } = null!;

        public ICollection<OrderDetail> OrderDetails { get;} = new List<OrderDetail>();
    }
}
