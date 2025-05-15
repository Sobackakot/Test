using Pipeline.Service.Client;

namespace Pipeline.Service
{
    public interface IService  
    {
        public ServiceRequirements _servicesProvided { get; set; }
        void Service(IClient client);
        IService SetNextServiceHandler(IService serviceHandler);
    }
    public enum ServiceRequirements { Dirty, EngineTune, TestDrive, WheelAlignment, None }
}
