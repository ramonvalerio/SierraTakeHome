using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.Core.Applications.Products;
using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _appService;

        public ProductController(IProductAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var result = await _appService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var result = await _appService.GetById(id);
            return Ok(result);
        }
    }
}
