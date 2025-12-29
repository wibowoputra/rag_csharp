using MediatR;
using Domain.Interfaces;
using Application.Orders.Queries;

namespace Application.Orders.Queries;
public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderDto?>
    {
        private readonly IOrderRepository _repo;
        public GetOrderHandler(IOrderRepository repo) => _repo = repo;

        public async Task<OrderDto?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _repo.GetByIdAsync(request.Id);
            if (order == null) return null;
            return new OrderDto(order.Id, order.CustomerName, order.CreatedAt, order.Total(),
                order.Items.Select(i => new OrderItemDto(i.Id, i.ProductName, i.Price, i.Quantity)));
        }
    }

