using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;
        public OrderRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(Order order) => await _db.Orders.AddAsync(order);

        public async Task<Order?> GetByIdAsync(Guid id)
            => await _db.Orders.Include(o => EF.Property<IEnumerable<OrderItem>>(o, "_items")).FirstOrDefaultAsync(o => o.Id == id);

        public Task SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);
    }
}
