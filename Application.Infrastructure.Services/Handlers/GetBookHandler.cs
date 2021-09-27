using Application.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Core.Messages.Queries;
using Application.Core.Interfaces;

namespace Application.Infrastructure.Services.Handlers
{
    public class GetBookHandler : IRequestHandler<GetQuery<Book>, Book>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetBookHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Book> Handle(GetQuery<Book> request, CancellationToken cancellationToken)
        {
            return await unitOfWork.BookRepository.GetAsync(request.id);
        }
    }
}
