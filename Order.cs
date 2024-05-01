using System;
namespace HTTPRoutingDemo.Database.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public int NumberOfItemsInOrder { get; set; }
    }
}
