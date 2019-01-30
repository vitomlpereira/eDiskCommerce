using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskCommerce.Commom.Pagging;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Enumerators;
using DiskCommerce.Domain.Interfaces;
using DiskCommerce.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiskCommerce.Service.Controllers
{
    [Route("api/buyers")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepository _buyerRepository;

        public BuyerController(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        [HttpGet()]
        public ActionResult<PagedResult<DiskViewModelResult>> Get(int actualPage = 1, int pageSize = 20)
        {
            return Ok(_buyerRepository.GetPagged(actualPage, pageSize));
        }

    }
}
