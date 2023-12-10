using AddressBook.Api.Data;
using WilderMinds.MinimalApiDiscovery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookContext>();
builder.Services.AddTransient<BookEntryFaker>();
builder.Services.AddTransient<AddressFaker>();

var app = builder.Build();

app.MapApis();

app.Run();

