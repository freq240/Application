using Application.Core.Entities;
using Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Infrastructure.Data
{
    public class BookRepository : IRepository<Book>
    {
        private readonly OrderContext orderContext;

        public BookRepository(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }
        public async Task CreateAsync(Book item)
        {
            await orderContext.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await orderContext.Books.FindAsync(id);

            if (book != null)
            {
                orderContext.Books.Remove(book);
            }
        }

        public async Task<Book> GetAsync(int id)
        {
            return await orderContext.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await orderContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(int id, Book newBook)
        {
            var book = await orderContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            book.Name = newBook.Name;
            book.Price = newBook.Price;

            orderContext.Books.Update(book);

            await orderContext.SaveChangesAsync();

        }

    }
}
