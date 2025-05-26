using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class FireServiceHandler : HandlerBotBase
{
    public override void Handle(IClient client)
    {
        if(client.elementType == ElementType.Fire)
        {
            Debug.Log("Firing");
            return;
        }
        base.Handle(client);
    }
}
