using Mapster;

namespace AddressBook.Api.Data;

public static class Maps
{
  public static IServiceCollection AddMapsterMaps(this IServiceCollection svcs)
  {
    var config = new TypeAdapterConfig();

    config.NewConfig<BookEntryModel, BookEntry>()
      .Ignore(e => e.Addresses);

    svcs.AddSingleton(config);

    return svcs;
  }
}
