using System.Threading.Tasks;

namespace DiskCommerce.Commom.Publisher
{
    public interface IPublisher
    {
        Task SendQuery<T>(T query) where T : Query;
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
