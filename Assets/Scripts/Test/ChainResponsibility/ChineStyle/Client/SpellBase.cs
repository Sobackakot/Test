 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain.Service.Client
{
    public abstract class SpellBase : ISpell
    {
        public SpellBase(SpellType spell)
        {
            _spell = spell;
        }
        protected private SpellType _spell = SpellType.Fire;
        public abstract SpellType spell { get; }
        public abstract void SetSpell(SpellType spell);
    }
}

