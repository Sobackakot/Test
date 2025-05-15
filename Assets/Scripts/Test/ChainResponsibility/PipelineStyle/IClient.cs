
namespace Pipeline.Service.Client
{
    public interface IClient
    {
        ServiceRequirements Requirements { get; set; }
        bool IsServiceComplete();
    } 
}

