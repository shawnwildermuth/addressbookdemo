using Microsoft.EntityFrameworkCore;

namespace AddressBook.Api.Data;

public class BookRepository(BookContext context) : IBookRepository
{

  public async Task<IEnumerable<BookEntry>> GetAllEntries()
  {
    return await context.BookEntries
      .Include(b => b.Addresses)
      //.Where(b => b.UserName == Thread.CurrentPrincipal?.Identity?.Name)
      .OrderBy(b => b.LastName)
      .ThenBy(b => b.FirstName)
      .ToListAsync();
  }

  public async Task<BookEntry?> GetEntry(int id)
  {
    return await context.BookEntries
      .Include(b => b.Addresses)
      .Where(b => b.Id == id)
      //.Where(b => b.UserName == Thread.CurrentPrincipal?.Identity?.Name)
      .FirstOrDefaultAsync();
  }

  public async Task<IEnumerable<Address>> GetAddressesForUser(int id)
  {
    var entry = await GetEntry(id);

    if (entry is null) return new List<Address>();

    return entry.Addresses;
  }


  public void Add<T>(T entity) where T : class
  {
    context.Add(entity);
  }

  public void Remove<T>(T entity) where T : class
  {
    context.Remove(entity);
  }

  public async Task<bool> SaveAllAsync()
  {
    return await context.SaveChangesAsync() > 0;
  }

}
