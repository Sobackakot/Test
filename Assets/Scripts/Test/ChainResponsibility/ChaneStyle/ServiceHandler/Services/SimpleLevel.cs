using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class SimpleLevel : LevelServiceBase
{
    public override void Handle(IGameLevel client)
    {
        //Debug.Log("And Simple Update");

        if (client.levelType == LevelType.Simple)
        { 
            return;
        }
        base.Handle(client);
    }
}
