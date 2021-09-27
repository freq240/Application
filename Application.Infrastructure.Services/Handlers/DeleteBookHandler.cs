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
    public class DeleteBookHandler : IRequestHandler<DeleteCommand<Book>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteBookHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCommand<Book> request, CancellationToken cancellationToken)
        {
            await unitOfWork.BookRepository.DeleteAsync(request.id);
            await unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
