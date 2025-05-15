using Chain.Service.Client;

namespace Chain.Service
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void Handle(IClient client);
    }
}

