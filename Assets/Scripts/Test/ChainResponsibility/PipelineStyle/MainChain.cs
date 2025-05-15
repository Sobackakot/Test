using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class MainChain : MonoBehaviour
{ 
    void Start()
    {
        var mechanic = new MechanicServiceHandler();
        var detailer = new DetailerServiceHandler();
        var wheels = new WheelSpecialistServiceHandler();
        var qa = new QualityControlServiceHandler();
        qa.SetNextServiceHandler(detailer);
        wheels.SetNextServiceHandler(qa);
        mechanic.SetNextServiceHandler(wheels);

        Debug.Log("Car 1 is dirty");
        
        mechanic.Service(new CarKlient { Requirements = ServiceRequirements.Dirty });

        Debug.Log("Car 2 requires full service");

        mechanic.Service(new CarKlient
        {
            Requirements = ServiceRequirements.Dirty |
            ServiceRequirements.EngineTune |
            ServiceRequirements.TestDrive |
            ServiceRequirements.WheelAlignment
        });
    } 
}
