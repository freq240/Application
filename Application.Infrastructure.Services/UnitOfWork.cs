﻿using Application.Core.Entities;
using Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly OrderContext orderContext;
        private IRepository<Book> bookRepository;
       

        public UnitOfWork(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }

        public IRepository<Book> BookRepository
        {
            get
            {
                return bookRepository = bookRepository ?? new BookRepository(orderContext);
            }
        }


        public async Task CommitAsync()
        {
            await orderContext.SaveChangesAsync();
        }
    }
}
