using Microsoft.EntityFrameworkCore;
using PizzaStoreApi.Data;
using PizzaStoreApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/pizzas", (ApplicationDBContext db) => {
    return db.Pizza.ToListAsync();
});

app.MapPost("/pizzas", async (Pizza pizza, ApplicationDBContext db) => {
    db.Pizza.Add(pizza);
    await db.SaveChangesAsync();

    return Results.Created($"/pizzas", pizza);
});

app.Run();

