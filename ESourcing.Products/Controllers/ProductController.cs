﻿using ESourcing.Products.Entities;
using ESourcing.Products.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ESourcing.Products.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        #region Variables

        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        #endregion
        #region Constructor
        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            this._productRepository = productRepository;
            this._logger = logger;
        }
        #endregion

        #region CRUD_Actions
        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetPRoducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}",Name ="GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product is null)
            {
                _logger.LogError($"Product with id : {id}, hasn't been found in database");
                return NotFound();
            }
            return Ok(product); 
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct([FromBody]Product product)
        {
             await _productRepository.Create(product);
            return CreatedAtRoute("GetProduct", new {id = product.Id}, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result = await _productRepository.Update(product);
            return Ok(result);
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }
        #endregion
    }
}
