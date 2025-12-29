using MediatR;
namespace Application.Orders.Queries
{

    public record GetOrderQuery(Guid Id) : IRequest<OrderDto?>;

    public record OrderDto(Guid Id, string CustomerName, DateTime CreatedAt, decimal Total, IEnumerable<OrderItemDto> Items);
    public record OrderItemDto(Guid Id, string ProductName, decimal Price, int Quantity);


}