using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiskCommerce.Commom.Publisher
{
    public sealed class Publisher : IPublisher
    {
        private readonly IMediator _mediator;

        public Publisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            try { 
            return _mediator.Publish(@event);

            } catch(Exception ex)
            {
                return null;
            }

        }

        public Task SendCommand<T>(T command) where T : Command
        {
              return _mediator.Send(command);
        }

        public Task SendQuery<T>(T query) where T : Query
        {
            throw new NotImplementedException();
        }
    }
}

