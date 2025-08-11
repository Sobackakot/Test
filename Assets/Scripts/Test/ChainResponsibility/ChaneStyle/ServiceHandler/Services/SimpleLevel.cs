using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class SimpleLevel : LevelServiceBase
{
    public override void Handle(IGameLevel client)
    { 
        if (client.levelType == LevelType.Simple)
        {
            Debug.Log("Simple Update ");
            return;
        }
        base.Handle(client);
    }
}
