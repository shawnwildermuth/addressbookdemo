using Mapster;
using WilderMinds.MinimalApiDiscovery;

namespace AddressBook.Api.Apis;

public class AddressesApi : IApi
{
  public void Register(IEndpointRouteBuilder builder)
  {
    var grp = builder.MapGroup("/api/book/entries/{id:int}/addresses");

    grp.MapGet("", GetAddresses);
  }

  public static async Task<IResult> GetAddresses(IBookRepository repository, int id)
  {
    var results = await repository.GetAddressesForUser(id);

    return Results.Ok(results.Adapt<IEnumerable<AddressModel>>());
  }
}
