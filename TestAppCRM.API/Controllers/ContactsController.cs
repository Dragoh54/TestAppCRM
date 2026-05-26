using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAppCRM.Application.Contacts.Commands.CreateContactCommand;
using TestAppCRM.Application.Contacts.Commands.DeleteContactCommand;
using TestAppCRM.Application.Contacts.Commands.UpdateContactCommand;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.Application.Contacts.Queries.GetContactByIdQuery;
using TestAppCRM.Application.Contacts.Queries.GetPaginatedContactsQuery;
using TestAppCRM.Application.Pagination;
using TestAppCRM.DomainModel.Exceptions;

namespace TestAppCRM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody]CreateContactRequestDto request)
    {
        var contact  = await _mediator.Send(new CreateContactCommand(request));
        
        return Ok(contact);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateContact(Guid id, [FromBody] UpdateContactRequestDto request)
    {
        if (id != request.Id)
        {
            throw new BadRequestException("Ids do not match");
        }

        var contact = await _mediator.Send(new UpdateContactCommand(request));
        
        return Ok(contact);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteContactCommand(id));

        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPaged([FromQuery] PaginatedPageRequest request)
    {
        var result = await _mediator.Send(new GetPaginatedContactsQuery(request));

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(GetContactByIdRequestDto request)
    {
        var result = await _mediator.Send(new GetContactByIdQuery(request));

        return Ok(result);
    }
}