using Microsoft.EntityFrameworkCore;
using SmartVendorSystemData.Data;
using SmartVendorSystemService.IService;
using SmartVendorSystemService.Service;
using Microsoft.EntityFrameworkCore;
using SmartVendorSystemData.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddScoped<IVendorService,VendorService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
