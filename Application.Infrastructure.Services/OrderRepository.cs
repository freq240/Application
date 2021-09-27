using Application.Core.Entities;
using Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Data
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly OrderContext orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }
        public async Task CreateAsync(Order item)
        {
            await orderContext.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await orderContext.Orders.FindAsync(id);

            if (order != null)
            {
                orderContext.Orders.Remove(order);
            }
        }

        public async Task<Order> GetAsync(int id)
        {
            return await orderContext.Orders.FindAsync(id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await orderContext.Orders.ToListAsync();
        }

        public async Task UpdateAsync(int id, Order newOrder)
        {
            var order = await orderContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            order = newOrder;
            await orderContext.SaveChangesAsync();
        }
    }
}
