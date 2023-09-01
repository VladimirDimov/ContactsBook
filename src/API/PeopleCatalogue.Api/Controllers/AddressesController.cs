using ContactsBook.Application.Features.Address.Commands.CreateAddress;
using ContactsBook.Application.Features.Contact.Commands.CreateContact;
using ContactsBook.Application.Features.Contact.Commands.UpdateContact;
using ContactsBook.Application.Features.Contact.Queries.GetAllContacts;
using ContactsBook.Application.Features.Contact.Queries.GetContactDetails;
using ContactsBook.Application.Features.Person.Commands.DeleteContact;
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

        //[HttpGet(Name = "GetAddresses")]
        //public async Task<IActionResult> Get()
        //{
        //    var contacts = await _mediator.Send(new GetContactsQuery());

        //    return Ok(contacts);
        //}

        //[HttpGet()]
        //[Route("{id}")]
        //public async Task<IActionResult> GetContactDetails([FromRoute] int id)
        //{
        //    var contacts = await _mediator.Send(new GetContactDetailsQuery(id));

        //    return Ok(contacts);
        //}

        [HttpPost()]
        public async Task<IActionResult> CreateContact(CreateAddressCommand command)
        {
            var contactId = await _mediator.Send(command);

            return Created("", contactId);
        }

        //[HttpPut()]
        //public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        //{
        //    await _mediator.Send(command);

        //    return Ok();
        //}

        //[HttpDelete()]
        //public async Task<IActionResult> UpdateContact(int id)
        //{
        //    await _mediator.Send(new DeleteContactCommand(id));

        //    return Ok();
        //}
    }
}