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
    [Route("api/disks")]
    [ApiController]
    public class DiskController : ControllerBase
    {
        private readonly IDiskReadRepositoy _diskReadOnlyRepositoy;

        public DiskController(IDiskReadRepositoy diskReadOnlyRepositoy)
        {
            _diskReadOnlyRepositoy = diskReadOnlyRepositoy;
        }

        [HttpGet()]
        public ActionResult<PagedResult<Disk>> GetByGenre(DiskGenreEnum genre,int actualPage = 1, int pageSize = 10)
        {
            // Todo: Divida técnica: Não retornar a entidade , mapear para ViewModel
            return Ok(_diskReadOnlyRepositoy.GetPagged(actualPage, pageSize, genre));
        }

        [HttpGet("{id}")]
        public ActionResult<Disk> GetDiskById(Guid id)
        {
          // Todo: Divida técnica: Não retornar a entidade , mapear para ViewModel

           Disk disk = _diskReadOnlyRepositoy.Get(id);

            if (disk == null)
                return NotFound();

            return Ok(disk);
        }

        
    }
}
