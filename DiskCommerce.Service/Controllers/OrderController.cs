using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskCommerce.Commom.Notifications;
using DiskCommerce.Commom.Pagging;
using DiskCommerce.Commom.Publisher;
using DiskCommerce.Domain.Commands;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Entities.OrderAggregate;
using DiskCommerce.Domain.Interfaces;
using DiskCommerce.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiskCommerce.Service.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : APIController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPublisher _publisher;

        public OrderController(IOrderRepository orderRepository,
                               IPublisher publisher, 
                               IUnitOfWork unitOfWork,
                               DomainNotificationHandler domainNotificationHandler): base(domainNotificationHandler, unitOfWork)
        {
            _orderRepository = orderRepository;
            _publisher = publisher;
            
        }


        [HttpGet("{id}")]
        public ActionResult<Order> Get(Guid id)
        {

            // Todo: Divida técnica: Não retornar a entidade , mapear para ViewModel

            var order = _orderRepository.Get(id);


            if (order == null)
                return NotFound();

            return Ok(_orderRepository.Get(id));
        }


        [HttpGet()]
        public ActionResult<PagedResult<Order>> GetPaged(DateTime begin, DateTime finalDate, int actualPage = 1, int pageSize = 10)
        {
            // Todo: Divida técnica: Não retornar a entidade , mapear para ViewModel
            return Ok(_orderRepository.GetPagged(actualPage, pageSize, begin, finalDate));
        }


        [HttpPost()]
        public IActionResult PlaceOrder(BasketViewModel basketViewModel)
        {
            var items = new Dictionary<Guid, int>();
            basketViewModel.BasketItems.ForEach(i => items.Add(i.DiskId, i.Units));

           var placeOrderCommand = new PlaceOrderCommand(basketViewModel.BuyerId, items);

            _publisher.SendCommand<PlaceOrderCommand>(placeOrderCommand);

            return Response(placeOrderCommand);
            
        }
    }
}
