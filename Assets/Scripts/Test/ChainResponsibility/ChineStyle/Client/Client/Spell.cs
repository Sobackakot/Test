using Chain.Service.Client;
using UnityEngine;

public class Spell : SpellBase
{
    public Spell(SpellType spell) : base(spell)
    {
    }
     
    public override SpellType spell => _spell;
    public override void SetSpell(SpellType spell)
    {
        if (this.spell == spell) return;
        _spell = spell;
        Debug.Log("start event change spell on " + spell);
    }
}
