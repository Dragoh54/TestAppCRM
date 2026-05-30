using Microsoft.EntityFrameworkCore;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.Application.Pagination;
using TestAppCRM.DataAccess.Context;
using TestAppCRM.DataAccess.Extensions;
using TestAppCRM.DomainModel;
using TestAppCRM.DomainModel.Entities;

namespace TestAppCRM.DataAccess.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly TestAppCrmDbContext _context;

    public ContactRepository(TestAppCrmDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Contact>> GetContactsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Contacts
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Contact?> GetContactByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Contacts
            .FirstOrDefaultAsync(contact => contact.Id == id, cancellationToken);
    }

    public async Task<Contact> AddAsync(Contact contact, CancellationToken cancellationToken = default)
    {
        var addedContact = await _context.Contacts.AddAsync(contact, cancellationToken);
        
        return addedContact.Entity;
    }

    public void Update(Contact contact)
    {
        _context.Contacts.Update(contact);
    }

    public void Delete(Contact contact)
    {
        _context.Contacts.Remove(contact);
    }

    public async Task<PaginatedList<Contact>> GetPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _context.Contacts
            .AsNoTracking()
            .ToPaginatedListAsync(
                page,
                pageSize,
                cancellationToken);
    }
}