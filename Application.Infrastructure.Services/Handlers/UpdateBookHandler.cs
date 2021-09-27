using Application.Core.Entities;
using Application.Core.Interfaces;
using Application.Core.Messages.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Infrastructure.Services.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateCommand<Book>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateBookHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(Core.Messages.Commands.UpdateCommand<Book> request, CancellationToken cancellationToken)
        {
            await unitOfWork.BookRepository.UpdateAsync(request.id, request.item);

            return Unit.Value;
        }
    }
}
