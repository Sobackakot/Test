using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class MechanicServiceHandler : ServiceCarHandler
{
    public MechanicServiceHandler() : base(ServiceRequirements.EngineTune)
    {
    }
}
