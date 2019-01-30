using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskCommerce.Commom.Notifications;
using DiskCommerce.Commom.Pagging;
using DiskCommerce.Commom.Publisher;
using DiskCommerce.Domain.Commands;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Entities.CashbackAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;
using DiskCommerce.Domain.Interfaces;
using DiskCommerce.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiskCommerce.Service.Controllers
{
    
    [ApiController]
    public class CashbackController : ControllerBase
    {
        private readonly ICashBackRepository _cashBackRepository;

        public CashbackController(ICashBackRepository cashBackRepository)
        {
            _cashBackRepository = cashBackRepository;
        }

        [HttpGet("api/orders/{orderID}/cashback")]
        public ActionResult<OrderCashback> Get(Guid orderID)
        {
            // Todo: Divida técnica: Não retornar a entidade , mapear para ViewModel
            var cashBack = _cashBackRepository.GetOrderCashBack(orderID);

            if (cashBack == null)
                return NotFound();

            return Ok();
        }
    
    }
}
