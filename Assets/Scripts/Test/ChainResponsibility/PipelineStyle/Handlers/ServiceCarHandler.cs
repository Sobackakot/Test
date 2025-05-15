using Chain.Service.Client;
using UnityEngine;

namespace Chain.Service 
{
    public abstract class ServiceCarHandler : IService
    {
        public ServiceCarHandler(ServiceRequirements servicesProvided)
        {
            _servicesProvided = servicesProvided;
        }
        public IService _nextServiceHandler { get; private set; }
        public ServiceRequirements _servicesProvided { get; set; } 
        public void Service(IClient client)
        {
            if (_servicesProvided == (client.Requirements & _servicesProvided))
            {
                Debug.Log($"{this.GetType().Name} providing {this._servicesProvided}services.");
                client.Requirements &= ~_servicesProvided;
            }
            if (client.IsServiceComplete() || _nextServiceHandler == null)
                return;
            else
                _nextServiceHandler.Service(client);
        }

        public void SetNextServiceHandler(IService serviceHandler)
        {
            _nextServiceHandler = serviceHandler;
        }
    }

}

