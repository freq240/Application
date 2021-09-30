using Application.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core.Entities;
using MediatR;
using Application.Core.Messages.Commands;
using Application.Core.Messages.Queries;
using Microsoft.AspNetCore.Cors;

namespace Application.API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all")]
       public async Task<IActionResult> GetAllBooks()
        {
            var response = await mediator.Send(new GetAllQuery<Book>());
            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var response = await mediator.Send(new GetQuery<Book>(id));
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book) => 
            Ok(await mediator.Send(new CreateCommand<Book>(book)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id) =>
            Ok(await mediator.Send(new DeleteCommand<Book>(id)));

        [HttpPut]
        public async Task<IActionResult> UpdateBook(int id, string name, double price) =>
            Ok(await mediator.Send(new UpdateCommand<Book>(id, name, price)));
        
    }
}
