using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class HardcoreLevel : LevelServiceBase
{
    public override void Handle(IGameLevel client)
    {
        //Debug.Log("And Hardcore Update");

        if (client.levelType == LevelType.Hardcore)
        {
            Debug.Log("Hardcore Update "); 
            return;
        }
        base.Handle(client);
    }
}
