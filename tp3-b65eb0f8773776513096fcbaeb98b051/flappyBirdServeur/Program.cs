using flappyBirdServeur.Data;
using flappyBirdServeur.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<flappyBirdServeurContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("flappyBirdServeurContext") ?? throw new InvalidOperationException("Connection string 'flappyBirdServeurContext' not found."));
    options.UseLazyLoadingProxies(); // Ceci
});
builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<flappyBirdServeurContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
