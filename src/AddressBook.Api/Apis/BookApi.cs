
using AddressBook.Api.Validators;
using Mapster;
using Microsoft.EntityFrameworkCore;
using WilderMinds.MinimalApiDiscovery;

namespace AddressBook.Api.Apis;

public class BookApi : IApi
{
  public void Register(IEndpointRouteBuilder builder)
  {
    var grp = builder.MapGroup("/api/book");

    grp.MapGet("", GetBook);
  }

  public static async Task<IResult> GetBook(IBookRepository repository)
  {
    var results = await repository.GetAllEntries();

    return Results.Ok(new BookModel()
    {
      BookEntries = results.Adapt<IEnumerable<BookEntryModel>>()
    });

  }




}
