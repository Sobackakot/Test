using UnityEngine;
using System;

public class HungerSensor : WorldFactSensor
{
    public HungerSensor(AgentContext Context) : base(Context)
    {
    }

    public override GOAPFact SenseFact()
    {
        // Чистая инкапсуляция логики:
        if (Context.IsCharacterHungry())
        {
            return new IsHungryFact(true);
        }

        // Если не голоден, возвращаем null (отсутствие факта = false)
        return null;
    }
}