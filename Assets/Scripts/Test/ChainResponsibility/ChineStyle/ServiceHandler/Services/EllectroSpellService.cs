using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class EllectroSpellService : DifficultyLevelServiceBase
{
    public override void Handle(IDifficultyLevel client)
    {
        //Debug.Log("And Middle Update");

        if(client.levelType == DifficultyLevelType.Middle)
        {
            Debug.Log("Only Middle Update ");
            return;
        }
        base.Handle(client);
    }

}
