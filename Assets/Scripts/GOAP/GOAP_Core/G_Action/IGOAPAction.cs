using System.Collections;

namespace EntityAI.GOAP.Action
{
    public interface IGOAPAction
    {
        string Name { get; }
        float Cost { get; }
        float BaseDuration { get; }
        float BaseFailChance { get; }
        ItemType[] RequiredItems { get; }
        IRandomizerService Randomizer { get; }


        bool CheckPreconditions(IBlackboard bb);
        void ApplyEffects(IBlackboard bb);
        IEnumerator Perform(IBlackboard bb);

        Item GetRelevantTool(IBlackboard bb);
    }
}
