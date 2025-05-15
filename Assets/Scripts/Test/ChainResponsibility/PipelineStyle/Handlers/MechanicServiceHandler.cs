using Pipeline.Service;
using Pipeline.Service.Client;
using UnityEngine;

public class MechanicServiceHandler : ServiceCarHandler
{
    public MechanicServiceHandler() : base(ServiceRequirements.EngineTune)
    {
    }
}
