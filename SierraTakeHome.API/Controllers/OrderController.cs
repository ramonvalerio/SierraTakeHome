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
            var result = await _appService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var result = await _appService.GetById(id);
            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task Post([FromBody] OrderDTO value)
        {
            var result = await _appService.Create(value);
            Ok(result);
        }
    }
}
