using Microsoft.EntityFrameworkCore;
using Promos.Application;
using Promos.Application.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PromotionsContext>();
    await context.Database.MigrateAsync();
}


app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();