using FirstApi.Data;
using FirstApi.Products.DTOs;
using FirstApi.Products.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Products.Routes;

public static class ProductRoute
{
    public static void ProductRoutes (this WebApplication app)
    {
        var routes = app.MapGroup("product");
        
        routes.MapPost("", 
            async (CreateProductRequest request, AppDbContext context) =>
            {
                var newProduct = new Product(request.Name, request.Price, request.Quantity);

                await context.Products.AddAsync(newProduct);
                await context.SaveChangesAsync();

                return Results.Created("", newProduct);
            });
        
        routes.MapGet("", 
            async (AppDbContext context) =>
            {
                var productsList = await context.Products.ToListAsync();

                return Results.Ok(productsList);
            });
        
    }
}