using InventoryManagementSystem.BLL.Manager.OrderManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class ReportsController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        public ReportsController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet("GetByDay")]
        public IActionResult GetOrdersByDay(DateTime date)
        {
            var orders = _orderManager.GetOrdersByDay(date);
            return Ok(orders);
        }
    }
}
