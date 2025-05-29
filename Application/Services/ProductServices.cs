using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.API.DTOs;
using OrderManagementAPI.Application.Exceptions;
using OrderManagementAPI.Domain.Entities;
using OrderManagementAPI.Infra.Database;

namespace OrderManagementAPI.Application.Services;

public class ProductServices
{
    public async Task<List<Product>> GetProducts(DatabaseContext context)
    {
        var productsList = await context.Products.ToListAsync();
        return productsList;
    }

    public async Task<Product> GetProductById(Guid id, DatabaseContext context)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null)
        {
            throw new ProductNotFoundException();
        }

        return product;
    }
    public async Task<Product> UpdateProductById(Guid id, UpdateProductRequest request, DatabaseContext context)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null)
        {
            throw new ProductNotFoundException();
        }

        product.UpdateProduct(request);

        await context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> CreateProduct(CreateProductRequest request, DatabaseContext context)
    {
        var newProduct = new Product(request.Name, request.Price, request.Quantity);

        await context.Products.AddAsync(newProduct);
        await context.SaveChangesAsync();

        return newProduct;
    }
}