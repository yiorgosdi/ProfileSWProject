using JwtAuthForUserLogin.Interfaces;
using JwtAuthForUserLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthForUserLogin.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService prodService)
    {
        this._productService = prodService;
    }

    [Authorize]
    [HttpGet("Get")]
    //[AllowAnonymous]//for-testing-only
    public async Task<ActionResult<List<Product>>> Get()
    {
        var result = await _productService.GetProductsAsync();
        
        return result;
    }
}
