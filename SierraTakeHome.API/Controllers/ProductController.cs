using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.Core.Application.Products;
using SierraTakeHome.Core.Domain.Products;

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
            try
            {
                var result = await _appService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            try
            {
                var result = await _appService.GetById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
