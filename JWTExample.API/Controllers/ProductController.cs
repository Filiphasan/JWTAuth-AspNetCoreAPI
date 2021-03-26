using JWTExample.Core.Dtos;
using JWTExample.Core.Models;
using JWTExample.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IServiceGeneric<Product, ProductDto> _productService;

        public ProductController(IServiceGeneric<Product, ProductDto> productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var result = await _productService.GetAllAsync();
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDto productDto)
        {
            var result = await _productService.AddAsync(productDto);
            return ActionResultInstance(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            var result = await _productService.Update(productDto, productDto.Id);
            return ActionResultInstance(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.Remove(id);
            return ActionResultInstance(result);
        }
    }
}
