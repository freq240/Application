using Application.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Messages.Queries
{
    // by id
    public record GetQuery<T>(int id) : IRequest<Book>
        where T: class;
}
