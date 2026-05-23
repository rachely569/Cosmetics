using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Cosmetics_Dal;
using Cosmetics_Bll;
using CosmeticsDTO;
using Cosmetics_Dal.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    option.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
builder.Services.AddScoped<ICategoriesDal, CategoryDal>();

builder.Services.AddScoped<IUsersBll, UsersBll>();
builder.Services.AddScoped<IUsersDal, UsersDal>();

builder.Services.AddScoped<IProductsBll, ProductsBll>();
builder.Services.AddScoped<IProductDal, ProductsDal>();

builder.Services.AddScoped<IOrdersBll, OrdersBll>();
builder.Services.AddScoped<IordersDal, OrdersDal>();

builder.Services.AddDbContext<SHOPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(p => p.AddPolicy("AlowAll", option =>
{
    option.AllowAnyMethod();
    option.AllowAnyHeader();
    option.AllowAnyOrigin();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AlowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();