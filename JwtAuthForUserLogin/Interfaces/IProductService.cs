using JwtAuthForUserLogin.Models;

namespace JwtAuthForUserLogin.Interfaces;

public interface IProductService
{
    public Task<List<Product>> GetProductsAsync();
}
