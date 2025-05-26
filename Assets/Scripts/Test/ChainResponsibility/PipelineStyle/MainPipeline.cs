using Pipeline.Service;
using Pipeline.Service.Client;
using UnityEngine;

public class MainPipeline : MonoBehaviour
{ 
    void Start()
    {
        var mechanic = new MechanicServiceHandler();
        var detailer = new DetailerServiceHandler();
        var wheels = new WheelSpecialistServiceHandler();
        var qa = new QualityControlServiceHandler();

        mechanic.SetNextServiceHandler(detailer);
        detailer.SetNextServiceHandler(wheels);
        wheels.SetNextServiceHandler(qa);

        mechanic.Service(new CarKlient { Requirements = ServiceRequirements.Dirty |
                   ServiceRequirements.EngineTune |
                   ServiceRequirements.TestDrive |
                   ServiceRequirements.WheelAlignment
        });   
    } 
}
