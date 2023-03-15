using Microsoft.EntityFrameworkCore;
using SecondRadencyTask.Domain;
using SecondRadencyTask.Persistance;
using System;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IRecommendedRepository, RecommendedRepository>();

builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryContext>(
    options => options.UseInMemoryDatabase(databaseName: "BooksDb"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<LibraryContext>();
    context.Database.EnsureCreated();
}
/*var context = app.Services.GetService<LibraryContext>();
context.Database.EnsureCreated();*/
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
