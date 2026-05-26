using Microsoft.EntityFrameworkCore;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.DataAccess.Context;
using TestAppCRM.DomainModel;

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

    public async Task<(List<Contact> Items, int TotalCount)> GetPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = _context.Contacts.AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        var contacts = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (contacts, totalCount);
    }
}