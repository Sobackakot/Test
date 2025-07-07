using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class FireSpellService : ServiceHandlerBase
{
    public override void Handle(ISpell client)
    {
        if(client.spell == SpellType.Fire)
        {
            Debug.Log("Firing update");
            return;
        }
        base.Handle(client);
    }
}
