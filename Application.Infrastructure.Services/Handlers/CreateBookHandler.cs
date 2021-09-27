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
    public class CreateBookHandler : IRequestHandler<CreateCommand<Book>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateBookHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateCommand<Book> request, CancellationToken cancellationToken)
        {
            await unitOfWork.BookRepository.CreateAsync(request.item);
            await unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
