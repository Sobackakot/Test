using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class HardcoreLevel : LevelServiceBase
{
    public override void Handle(IGameLevel client)
    { 
        if (client.levelType == LevelType.Hardcore)
        {
            Debug.Log("Hardcore Update "); 
            return;
        }
        base.Handle(client);
    }
}
