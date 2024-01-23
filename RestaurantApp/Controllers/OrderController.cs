using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BL;
using RestaurantApp.BL.DTOs.OrderItemsDto;
using RestaurantApp.BL.DTOs.Orders;
using RestaurantApp.BL.Managers.Orders;
using System.Security.Claims;

namespace RestaurantApp.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersManager ordersManager;
        private readonly IOrderItemsManager orderItems;

        public OrderController(IOrdersManager ordersManager,IOrderItemsManager orderItems)
        {
            this.ordersManager = ordersManager;
            this.orderItems = orderItems;
        }

        [HttpGet]
        public ActionResult<List<OrderReadDto>> GetAllOrders()
        {
            return ordersManager.GetOrders().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Order = ordersManager.GetOrder(id);

            if (Order is null)
            {
                return BadRequest();
            }

            return Order;
        }

        [HttpGet]
        [Route("/items/{id}")]
        public ActionResult<List<OrderItemsReadDto>> GetOrderItems(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Order = orderItems.GetByOrderId(id);

            if (Order is null)
            {
                return BadRequest();
            }

            return Order.ToList();
        }

        [HttpGet]
        [Route("/owner/{id}")]
        public ActionResult<List<OrderReadDto>> GetOrderByUserId(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Order = ordersManager.GetOrderByUserId(id);

            if (Order is null)
            {
                return BadRequest();
            }

            return Order.ToList();
        }

       

        [Authorize]
        [HttpPost]
        public ActionResult AddOrder(OrderAddDto order)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newOrder = ordersManager.AddOrder(order,userId);

            return Ok(new { message = "order "+newOrder+ " added successfully" });
        }

    }
}
