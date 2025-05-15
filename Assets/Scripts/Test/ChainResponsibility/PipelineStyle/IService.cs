using Chain.Service.Client;

namespace Chain.Service
{
    public interface IService  
    {
        public ServiceRequirements _servicesProvided { get; set; }
        void Service(IClient client);
        void SetNextServiceHandler(IService serviceHandler);
    }
    public enum ServiceRequirements { Dirty, EngineTune, TestDrive, WheelAlignment, None }
}
