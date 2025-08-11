using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class MiddleLevel : LevelServiceBase
{ 
    public override void Handle(IGameLevel client)
    { 
        if(client.levelType == LevelType.Middle)
        { 
            Debug.Log("Middle Update ");  
            return;
        }
        base.Handle(client);
    }

}
