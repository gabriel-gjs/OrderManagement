using OrderManagementAPI.API.DTOs;
using OrderManagementAPI.Application.Services;
using OrderManagementAPI.Infra.Database;

namespace OrderManagementAPI.API.Controllers;

public static class ProductController
{
    public static void ProductRoutes(this WebApplication app)
    {
        var routes = app.MapGroup("product");
        var productServices = new ProductServices();

        routes.MapPost("",
            async (CreateProductRequest request, DatabaseContext context) =>
            {
                var product = await productServices.createProduct(request, context);

                return Results.Created("", product);
            });

        routes.MapGet("",
            async (DatabaseContext context) =>
            {
                var list = await productServices.getProducts(context);

                return Results.Ok(list);
            });

    }
}