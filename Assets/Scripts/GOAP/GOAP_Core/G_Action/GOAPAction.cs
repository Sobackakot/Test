using System;
using System.Collections;
using System.Collections.Generic;

public abstract class GOAPAction  : IGOAPAction
{
    protected string _Name;
    string IGOAPAction.Name => _Name;


    protected float _Cost = 1f;
    float IGOAPAction.Cost => _Cost;


    public float _BaseDuration = 4f;
    float IGOAPAction.BaseDuration => _BaseDuration;


    protected float _BaseFailChance = 0.1f;
    float IGOAPAction.BaseFailChance => _BaseFailChance;


    protected ItemType[] _RequiredItems = new ItemType[0];
    ItemType[] IGOAPAction.RequiredItems => _RequiredItems;


    protected IRandomizerService _Randomizer;
    public IRandomizerService Randomizer => _Randomizer;


    protected GOAPAction(IRandomizerService randomizer)
    {
        _Randomizer = randomizer;
    }

    public abstract bool CheckPreconditions(IBlackboard bb);
    public abstract void ApplyEffects(IBlackboard bb);
    public abstract IEnumerator Perform(IBlackboard bb);

    public Item GetRelevantTool(IBlackboard bb)
    {
        if (_RequiredItems == null || _RequiredItems.Length == 0) return null;

        foreach (var type in _RequiredItems)
        {
            var item = bb.Inventory.GetBest(type);
            if (item != null) return item;
        }
        return null;
    }  
}