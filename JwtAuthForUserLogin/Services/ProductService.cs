using JwtAuthForUserLogin.Interfaces;
using JwtAuthForUserLogin.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Net;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JwtAuthForUserLogin.Services
{
    public class ProductService : IProductService 
    {
        private readonly IConfiguration _config;

        public ProductService(IConfiguration config)
        {
            this._config = config;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var prodUrl = "https://fakestoreapi.com";
            RestClient restClient = new RestClient(prodUrl);
            RestRequest request = new RestRequest("products", Method.Get);         

            var response = await restClient.ExecuteAsync<List<Product>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException($"Cannot get products from site. {response.ErrorMessage}");
            }
            return response.Data; 
        }
    }
}
