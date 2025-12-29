using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }
        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public DateTime CreatedAt { get; private set; }

        private Order() { }
        public Order(string customerName)
        {
            Id = Guid.NewGuid();
            CustomerName = customerName;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddItem(string productName, decimal price, int qty)
        {
            if (string.IsNullOrWhiteSpace(productName)) throw new ArgumentException("product");
            _items.Add(new OrderItem(productName, price, qty));
        }

        public decimal Total() => _items.Sum(i => i.Price * i.Quantity);
    }

    public class OrderItem
    {
        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }


        private OrderItem() { }  // for EF
        public OrderItem(string productName, decimal price, int quantity)
        {
            Id = Guid.NewGuid();
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }
}
