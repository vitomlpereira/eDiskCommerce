using DiskCommerce.Commom.Notifications;
using DiskCommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DiskCommerce.Service.Controllers
{
    public abstract class APIController : Controller
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;
        private readonly IUnitOfWork _unitOfWork;

        public APIController(DomainNotificationHandler domainNotificationHandler, IUnitOfWork unitOfWork)
        {
            _domainNotificationHandler = domainNotificationHandler;
            _unitOfWork = unitOfWork;
        }

        protected bool IsCommandSucceed()
        {
            return (!_domainNotificationHandler.HasNotifications());
        }
        protected new IActionResult Response(object result = null)
        {
            if (IsCommandSucceed())
            {
                if (Commit())
                    return Ok(new
                    {
                        sucess = true,
                        result
                    });
                else return BadRequest(new
                {
                    sucess = false,
                    errors = "Error to commit to Database"
                });
            }
            else
            {
                return BadRequest(new
                {
                    sucess = false,
                    errors = _domainNotificationHandler.GetNotifications().Select(x => x.Value)
                });

            }
        }

   

        private Boolean Commit()
        {
            return _unitOfWork.Commit();
        }

    }
}
