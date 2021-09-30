﻿using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
        Task CommitAsync();
    }
}
