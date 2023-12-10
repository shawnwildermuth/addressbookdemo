using AddressBook.Api.Data;
using Microsoft.EntityFrameworkCore;
using WilderMinds.MinimalApiDiscovery;

namespace AddressBook.Api.Apis;

public class EntriesApi : IApi
{
  public void Register(IEndpointRouteBuilder builder)
  {
    var grp = builder.MapGroup("/api/entries");

    grp.MapGet("", (BookContext context) =>
    {
      var results = context.BookEntries
        .Include(b => b.Addresses)
        .ToList();

      return Results.Ok(results);
    });
  }
}
