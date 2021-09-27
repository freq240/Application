using Application.Core.Entities;
using Application.Core.Interfaces;
using Application.Core.Messages.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Infrastructure.Services.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllQuery<Book>, List<Book>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllBooksHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Book>> Handle(GetAllQuery<Book> request, CancellationToken cancellationToken)
        {
            return await unitOfWork.BookRepository.GetAllAsync();
        }
    }
}
