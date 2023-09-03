using ContactsBook.Application.Features.Address.Commands.CreateAddress;
using ContactsBook.Application.Features.Address.Commands.DeleteAddress;
using ContactsBook.Application.Features.Address.Queries.GetAddressDetails;
using ContactsBook.Application.Features.Person.Commands.DeleteContact;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactsBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ContactsController> _logger;

        public AddressesController(
            IMediator mediator,
            ILogger<ContactsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetAddressDetails")]
        public async Task<IActionResult> Get(int id)
        {
            var contacts = await _mediator.Send(new GetAddressDetailsQuery(id));

            return Ok(contacts);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            var contactId = await _mediator.Send(command);

            return Created("", contactId);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateContact(UpdateAddressCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _mediator.Send(new DeleteAddressCommand(id));

            return Ok();
        }
    }
}