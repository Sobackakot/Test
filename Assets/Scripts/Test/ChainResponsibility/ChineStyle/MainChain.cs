using Chain.Service;
using Chain.Service.Client; 
using UnityEngine;

public class MainChain : MonoBehaviour
{
    private IHandler handler;
    private IClient client;
    void Start()
    {
        client = new EnemyCient();
        handler = new FreezServiceHandler();
        handler.SetNext(new FireServiceHandler())
            .SetNext(new EllectroServiceHandler()); 
         
    }
     
    void Update()
    {
        handler.Handle(client);
    }
}
