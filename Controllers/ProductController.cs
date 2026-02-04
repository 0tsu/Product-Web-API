using Estudo.DTOs;
using Estudo.Models;
using Estudo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estudo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
            => Ok(_service.ListAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.Search(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [Authorize(Policy = "ProductCreate")]
        [HttpPost]
        public IActionResult Post(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            _service.Create(product);
            return Created("", product);
        }
    }
}
