using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Messages.Commands
{
    public record CreateCommand<T>(T item): IRequest
        where T: class;


}
