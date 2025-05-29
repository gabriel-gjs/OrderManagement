using OrderManagementAPI.API.DTOs;

namespace OrderManagementAPI.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        IsActive = true;
        Id = Guid.NewGuid();
    }

    public void UpdateProduct(UpdateProductRequest request)
    {
        Name = request.Name;
        Price = request.Price;
        Quantity = request.Quantity;
    }
}