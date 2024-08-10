using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }
    }
}
