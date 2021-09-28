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
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [EnableCors]
        [HttpGet("/get/all")]
       public async Task<IActionResult> GetAllBooks()
        {
            var response = await mediator.Send(new GetAllQuery<Book>());
            return response == null ? NotFound() : Ok(response);
        }
        [EnableCors]
        [HttpGet("/get/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var response = await mediator.Send(new GetQuery<Book>(id));
            return response == null ? NotFound() : Ok(response);
        }
        [EnableCors]
        [HttpPost("/add/{name}/{price}")]
        public async Task<IActionResult> AddBook(string name, double price) => 
            Ok(await mediator.Send(new CreateCommand<Book>(new Book(name, price))));

        [EnableCors]
        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> DeleteBook(int id) =>
            Ok(await mediator.Send(new DeleteCommand<Book>(id)));

        [EnableCors]
        [HttpPut("/update/{id}/{name}/{price}")]
        public async Task<IActionResult> UpdateBook(int id, string name, double price) =>
            Ok(await mediator.Send(new UpdateCommand<Book>(id, new Book(name, price))));
        
    }
}
