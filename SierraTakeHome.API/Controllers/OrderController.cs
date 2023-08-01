using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.Core.Applications.Orders;
using SierraTakeHome.Core.Models.Orders;

namespace SierraTakeHome.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _appService;

        public OrderController(IOrderAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var result = await _appService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            try
            {
                var result = await _appService.GetById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task Post([FromBody] OrderDTO value)
        {
            try
            {
                var result = await _appService.Create(value);
                Ok(result);
            }
            catch (Exception ex)
            {
                NotFound(ex.Message);
            }
        }
    }
}
