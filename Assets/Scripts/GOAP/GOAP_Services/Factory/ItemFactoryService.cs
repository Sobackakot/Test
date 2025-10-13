using System;
using System.Collections.Generic; 

// ItemFactoryService: Реализует логику создания предметов с учетом шансов качества.
public class ItemFactoryService : IItemFactory
{
    private readonly IRandomizerService _randomizer;
    public ItemFactoryService(IRandomizerService randomizer) { _randomizer = randomizer; }

    public Item CreateFound(ItemType type)
    {
        float roll = _randomizer.GetRandomFloat();
        float quality = (roll < 0.8f) ? (50f + _randomizer.GetRandomFloat() * 25.0f) : (80f + _randomizer.GetRandomFloat() * 20.0f);
        return new Item(type, quality);
    }

    public Item CreateSelfMade(ItemType type)
    {
        float roll = _randomizer.GetRandomFloat();
        float quality = (roll < 0.8f) ? (80f + _randomizer.GetRandomFloat() * 20.0f) : (50f + _randomizer.GetRandomFloat() * 30.0f);
        return new Item(type, quality);
    }
}
