using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class EllectroSpellService : ServiceHandlerBase
{
    public override void Handle(ISpell client)
    {
        if(client.spell == SpellType.Ellectro)
        {
            Debug.Log("Ellectring update");
            return;
        }
        base.Handle(client);
    }

}
