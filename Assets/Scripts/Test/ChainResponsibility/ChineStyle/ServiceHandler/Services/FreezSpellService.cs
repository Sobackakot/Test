 
using UnityEngine;
using Chain.Service.Client;
using Chain.Service;
public class FreezSpellService : DifficultyLevelServiceBase
{
    public override void Handle(IDifficultyLevel client)
    {
        //Debug.Log("And Simple Update");

        if (client.levelType == DifficultyLevelType.Simple)
        {
            Debug.Log("Only Simple Update");
            return;
        }
        base.Handle(client);
    }
}
