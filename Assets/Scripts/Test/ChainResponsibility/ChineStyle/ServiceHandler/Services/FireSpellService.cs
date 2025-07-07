using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class FireSpellService : DifficultyLevelServiceBase
{
    public override void Handle(IDifficultyLevel client)
    {
        //Debug.Log("And Hardcore Update");

        if (client.levelType == DifficultyLevelType.Hardcore)
        {
            Debug.Log("Only Hardcore Update");
            return;
        }
        base.Handle(client);
    }
}
