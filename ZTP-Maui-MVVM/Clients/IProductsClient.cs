using Refit;
using ZTP_Maui_MVVM.Models;

namespace ZTP_Maui_MVVM.Clients;

public interface IProductsClient
{
    [Get("/Products")]
    Task<ApiResponse<List<Product>>> GetProducts();
    
    [Get("/Products/{id}")]
    Task<ApiResponse<Product>> GetProduct(string id);

    [Post("/Products")]
    Task<ApiResponse<Product>> PostProduct([Body] Product product);

    [Put("/Products/{id}")]
    Task<ApiResponse<Product>> PutProduct(string id, [Body] Product product);
    
    [Delete("/Products/{id}")]
    Task<IApiResponse> DeleteProduct(string id);
}