
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
    grp.MapGet("entries", GetEntries);
    grp.MapPost("entries", PostEntry)
      .Validate<BookEntryModel>();
  }

  public static async Task<IResult> GetBook(IBookRepository repository)
  {
    var results = await repository.GetAllEntries();

    return Results.Ok(new BookModel()
    {
      BookEntries = results.Adapt<IEnumerable<BookEntryModel>>()
    });

  }

  public async Task<IResult> PostEntry(IBookRepository repository, BookEntryModel model)
  {
    var entity = model.Adapt<BookEntry>();
    if (entity is not null)
    {
      foreach (var address in entity.Addresses)
      {
        repository.Add(address);
      }
      repository.Add(entity);

      if (await repository.SaveAllAsync())
      {
        return Results.Created($"/api/book/entries/{entity.Id}", entity.Adapt<BookEntryModel>());
      }
    }

    return Results.Problem("Failed to create new book entry");
  }


  public static async Task<IResult> GetEntries(IBookRepository repository)
  {
    var results = await repository.GetAllEntries();

    return Results.Ok(results.Adapt<IEnumerable<BookEntryModel>>());
  }


}
