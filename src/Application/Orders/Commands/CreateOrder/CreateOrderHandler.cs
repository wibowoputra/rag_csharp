using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _repo;
        public CreateOrderHandler(IOrderRepository repo) => _repo = repo;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.CustomerName);
            foreach (var it in request.Items)
                order.AddItem(it.ProductName, it.Price, it.Quantity);

            await _repo.AddAsync(order);
            await _repo.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}
