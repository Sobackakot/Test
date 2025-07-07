using Chain.Service;
using Chain.Service.Client; 
using UnityEngine;

public class MainChain : MonoBehaviour
{
    public SpellType spellType;
    private IServiceHandler service;
    private ISpell spell;
    void Start()
    {
        spell = new Spell(SpellType.Ellectro);
        
        service = new FreezSpellService();

        service.SetNext(new FireSpellService()).SetNext(new EllectroSpellService()); 
         
    }
     
    void Update()
    {
        spell.SetSpell(spellType);
        service.Handle(spell);
    }
}
