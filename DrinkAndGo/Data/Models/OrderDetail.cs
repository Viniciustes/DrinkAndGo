using System;
using System.ComponentModel.DataAnnotations;

namespace DrinkAndGo.Data.Models
{
    public class OrderDetail
    {
        public OrderDetail(Guid orderId, int drinkId, int amount, decimal price)
        {
            OrderDetailId = Guid.NewGuid();
            OrderId = orderId;
            DrinkId = drinkId;
            Amount = amount;
            Price = price;
        }

        [Key]
        public Guid OrderDetailId { get; private set; }
        public Guid OrderId { get; private set; }
        public int DrinkId { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }
        public virtual Drink Drink { get; set; }
        public virtual Order Order { get; set; }
    }
}