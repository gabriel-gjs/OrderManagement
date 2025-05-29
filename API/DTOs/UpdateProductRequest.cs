namespace OrderManagementAPI.API.DTOs;

public record UpdateProductRequest(string Name, double Price, int Quantity);