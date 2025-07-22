using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class MiddleLevel : LevelServiceBase
{ 
    public override void Handle(IGameLevel client)
    {
        //Debug.Log("And Middle Update");

        if(client.levelType == LevelType.Middle)
        { 
            Debug.Log("Middle Update ");  
            return;
        }
        base.Handle(client);
    }

}
