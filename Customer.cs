using System;
namespace HTTPRoutingDemo.Database.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public double Balance { get; set; }
    }
}
