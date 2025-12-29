using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.Commands
{
    public record CreateOrderCommand(string CustomerName, List<CreateOrderItemDto> Items) : IRequest<Guid>;

    public record CreateOrderItemDto(string ProductName, decimal Price, int Quantity);

}
