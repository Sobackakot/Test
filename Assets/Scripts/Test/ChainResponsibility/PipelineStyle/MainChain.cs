using Pipeline.Service;
using Pipeline.Service.Client;
using UnityEngine;

public class MainChain : MonoBehaviour
{ 
    void Start()
    {
        var mechanic = new MechanicServiceHandler();
        var detailer = new DetailerServiceHandler();
        var wheels = new WheelSpecialistServiceHandler();
        var qa = new QualityControlServiceHandler();


        mechanic.Service(new CarKlient { Requirements = ServiceRequirements.EngineTune });
        mechanic.SetNextServiceHandler(wheels);

        wheels.Service(new CarKlient { Requirements = ServiceRequirements.WheelAlignment });
        wheels.SetNextServiceHandler(detailer);

        detailer.Service(new CarKlient { Requirements = ServiceRequirements.Dirty });
        detailer.SetNextServiceHandler(qa);

        qa.Service(new CarKlient { Requirements = ServiceRequirements.TestDrive });
        
    } 
}
