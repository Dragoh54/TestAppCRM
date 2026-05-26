using TestAppCRM.DomainModel;
using TestAppCRM.DomainModel.Entities;

namespace TestAppCRM.Application.Interfaces.Repositories;

public interface IContactRepository
{
    Task<List<Contact>> GetContactsAsync(CancellationToken cancellationToken = default);
    
    Task<Contact?> GetContactByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<Contact> AddAsync(Contact contact, CancellationToken cancellationToken = default);
    
    void Update(Contact contact);
    
    void Delete(Contact contact);

    Task<(List<Contact> Items, int TotalCount)> GetPaginatedAsync(
        int page, int pageSize, CancellationToken cancellationToken = default);
}