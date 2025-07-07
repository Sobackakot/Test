 
using UnityEngine;
using Chain.Service.Client;
using Chain.Service;
public class FreezSpellService : ServiceHandlerBase
{
    public override void Handle(ISpell client)
    { 
        if(client.spell == SpellType.Freez)
        {
            Debug.Log("Freezing update");
            return;
        }
        base.Handle(client);
    }
}
