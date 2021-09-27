using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Messages.Queries
{
    public record GetAllQuery<T>: IRequest<List<T>>
        where T: class;
}
