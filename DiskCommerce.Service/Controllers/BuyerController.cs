using DiskCommerce.Commom.Pagging;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Interfaces;
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
        public ActionResult<PagedResult<Disk>> Get(int actualPage = 1, int pageSize = 20)
        {
            return Ok(_buyerRepository.GetPagged(actualPage, pageSize));
        }

    }
}
