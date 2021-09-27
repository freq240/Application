using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Messages.Commands
{
    public record DeleteCommand<T>(int id): IRequest 
        where T: class;
}
