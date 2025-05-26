using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class EllectroServiceHandler : HandlerBotBase
{
    public override void Handle(IClient client)
    {
        if(client.elementType == ElementType.Fire)
        {
            Debug.Log("Ellecting");
            return;
        }
        base.Handle(client);
    }

}
