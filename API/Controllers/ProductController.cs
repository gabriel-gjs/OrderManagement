using OrderManagementAPI.API.DTOs;
using OrderManagementAPI.Application.Exceptions;
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
                try
                {
                    var product = await productServices.CreateProduct(request, context);
                    return Results.Created("", product);
                }
                catch (Exception)
                {
                    return Results.Problem("Erro interno do Servidor.");
                }
            });

        routes.MapGet("",
            async (DatabaseContext context) =>
            {
                try
                {
                    var list = await productServices.GetProducts(context);
                    return Results.Ok(list);
                }
                catch (Exception)
                {
                    return Results.Problem("Erro interno do Servidor.");
                }
            });

        routes.MapGet("{id}",
            async (Guid id, DatabaseContext context) =>
            {
                try
                {
                    var product = await productServices.GetProductById(id, context);
                    return Results.Ok(product);
                }
                catch (ProductNotFoundException ex)
                {
                    return Results.NotFound(new { message = ex.Message });
                }
                catch (Exception)
                {
                    return Results.Problem("Erro interno do Servidor.");
                }
            });

        routes.MapPut("{id}",
            async (Guid id, UpdateProductRequest request, DatabaseContext context) =>
            {
                try
                {
                    var product = await productServices.UpdateProductById(id, request, context);
                    return Results.Ok(product);
                }
                catch (ProductNotFoundException ex)
                {
                    return Results.NotFound(new { message = ex.Message });
                }
                catch (Exception)
                {
                    return Results.Problem("Erro interno do Servidor.");
                }
            });
    }
}