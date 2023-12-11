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
