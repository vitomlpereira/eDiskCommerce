namespace DiskCommerce.Commom.Publisher
{

    public abstract class Message : MediatR.IRequest
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
