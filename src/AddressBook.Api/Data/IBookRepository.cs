
namespace AddressBook.Api.Data
{
  public interface IBookRepository
  {
    Task<IEnumerable<BookEntry>> GetAllEntries();
    Task<BookEntry?> GetEntry(int id);

    Task<IEnumerable<Address>> GetAddressesForUser(int id);


    void Add<T>(T entity) where T : class;
    void Remove<T>(T entity) where T : class;

    Task<bool> SaveAllAsync();
  }
}