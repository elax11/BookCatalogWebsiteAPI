using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SecondRadencyTask.Domain;
using SecondRadencyTask.Persistance;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactPolicy",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IRecommendedRepository, RecommendedRepository>();
builder.Services.AddScoped<ILibraryConfiguration, LibraryConfiguration>();

builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryContext>(
    options => options.UseSqlServer("data source=.;MultipleActiveResultSets=true;initial catalog=LibraryContextDB;user id=testuser;password=test;Encrypt=False"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<LibraryContext>();
    /*context.Database.EnsureDeleted();*/
    context.Database.EnsureCreated();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("ReactPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
