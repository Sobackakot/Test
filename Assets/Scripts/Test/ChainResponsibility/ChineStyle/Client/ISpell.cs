using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain.Service.Client
{
    public interface ISpell
    {
        SpellType spell { get;}
        void SetSpell(SpellType spell);
    }
    public enum SpellType
    {
       Freez,
       Ellectro,
       Fire,
       None
    }
}

