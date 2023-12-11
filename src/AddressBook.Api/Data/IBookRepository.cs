
namespace AddressBook.Api.Data
{
  public interface IBookRepository
  {
    void Add<T>(T entity) where T : class;
    Task<IEnumerable<BookEntry>> GetAllEntries();
    void Remove<T>(T entity) where T : class;
    Task<bool> SaveAllAsync();
  }
}