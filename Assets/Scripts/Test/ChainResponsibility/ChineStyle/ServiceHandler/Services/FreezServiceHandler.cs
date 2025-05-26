 
using UnityEngine;
using Chain.Service.Client;
using Chain.Service;
public class FreezServiceHandler : HandlerBotBase
{
    public override void Handle(IClient client)
    { 
        if(client.elementType == ElementType.Fire)
        {
            Debug.Log("Freezing ");
            return;
        }
        base.Handle(client);
    }
}
