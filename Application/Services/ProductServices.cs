using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.API.DTOs;
using OrderManagementAPI.Domain.Entities;
using OrderManagementAPI.Infra.Database;

namespace OrderManagementAPI.Application.Services;

public class ProductServices
{
    public async Task<List<Product>> getProducts(DatabaseContext context)
    {
        var productsList = await context.Products.ToListAsync();
        return productsList;
    }
    
    public async Task<Product> createProduct(CreateProductRequest request, DatabaseContext context)
    {
        var newProduct = new Product(request.Name, request.Price, request.Quantity);

        await context.Products.AddAsync(newProduct);
        await context.SaveChangesAsync();

        return newProduct;
    }
}