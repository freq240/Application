using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Messages.Commands
{
    public record UpdateCommand<T>(int id, string name, double price): IRequest
        where T: class;
}
