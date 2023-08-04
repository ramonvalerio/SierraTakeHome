using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.Core.Application.Customers;
using SierraTakeHome.Core.Domain.Customers;

namespace SierraTakeHome.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _appService;

        public CustomerController(ICustomerAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            try
            {
                var result = await _appService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
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
