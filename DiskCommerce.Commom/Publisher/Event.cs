using MediatR;

namespace DiskCommerce.Commom.Publisher
{
    public abstract class Event : Message, INotification
    {

    }
}
