using System;
using System.Collections.Generic;
using UnityEngine;


// ContextUpdaterService: Отвечает за симуляцию реального времени (тики, износ, расход энергии).
public class ContextUpdaterService : IContextUpdater
{
    private const float EnergyDrainPerSec = 1f;
    private const float EnergyRestoreOnReserveUse = 100f;
    private const float HungerDrainPerSec = 0.5f;

    private readonly IRandomizerService _randomizer;
    public ContextUpdaterService(IRandomizerService randomizer) { _randomizer = randomizer; }

    public void Tick(IBlackboard bb, Item toolUsed, float deltaTime)
    {
        // Energy
        if (bb.TryGet<EnergyProperty>(out var e))
        {
            e.Value = Mathf.Max(0f, e.Value - EnergyDrainPerSec * deltaTime);
            if (e.Value <= 0f && bb.TryGet<FoodReserveProp>(out var fr) && fr.Value > 0)
            {
                fr.Value -= 1;
                e.Value = EnergyRestoreOnReserveUse;
            }
        }

        // Tool Wear
        if (toolUsed != null)
        {
            toolUsed.Durability = Mathf.Max(0f, toolUsed.Durability - 1f * deltaTime);
            if (toolUsed.IsBroken) bb.Inventory.RemoveBroken();
        }

        // Hunger
        if (bb.TryGet<HungerProperty>(out var h))
        {
            h.Value = Mathf.Min(100f, h.Value + HungerDrainPerSec * deltaTime);
        }
    }

    public void TickIdle(IBlackboard bb, float deltaTime)
    {
        if (bb.TryGet<HungerProperty>(out var h))
        {
            h.Value = Mathf.Min(100f, h.Value + HungerDrainPerSec * deltaTime * 2f);
        }
    }

    public void HandleFailureEffects(IBlackboard bb, Item toolUsed, float qualityPercentage)
    {
        // Energy loss on failure
        if (bb.TryGet<EnergyProperty>(out var e)) e.Value = Mathf.Max(0f, e.Value - 10f);

        // Tool Break chance
        if (toolUsed != null)
        {
            float breakChance = _randomizer.CalculateBreakChanceOnFail(qualityPercentage);
            if (_randomizer.GetRandomFloat() < breakChance)
            {
                toolUsed.Durability = 0f;
                bb.Inventory.RemoveBroken();
            }
        }
    }
}