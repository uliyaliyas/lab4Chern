using lab4Chern;
using lab4Chern.Data;

using Microsoft.EntityFrameworkCore;
using lab4Chern.DAO;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddDbContext<BlogDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFlightRepository,FlightRepository>();
builder.Services.AddScoped<IPassengersRepository, PassengersRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddGraphQLServer().
AddMutationType<Mutation>().AddProjections().
AddSorting().AddFiltering().AddInMemorySubscriptions();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(cors => cors
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials()
);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<BlogDbContext>();
    dbContext?.Database.EnsureCreated();
    DataSeeder.SeedData(dbContext!);
}

app.MapGraphQL("/graphgl");

app.Run();
