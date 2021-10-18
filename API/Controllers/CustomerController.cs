using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Customer;
using Application.Queries.Customer;
using Core.Entities;
using Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery.Query());
            return result.Value;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Customer> CreateCustomer([FromBody] CreateCustomerCommand.Command cmd)
        {
            var result = await _mediator.Send(cmd);
            return result.Value;
        }

    }
}