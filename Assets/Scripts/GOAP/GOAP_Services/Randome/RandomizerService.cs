// RandomizerService: Чистый сервис для расчета случайных факторов и штрафов. 
// Является чистой реализацией IRandomizerService.
using UnityEngine;

public class RandomizerService : IRandomizerService
{
    private const float timePenaltyScale = 0.4f;
    private const float failPenaltyScale = 0.3f;
    private const float jitterMax = 0.12f;

    public float GetRandomFloat() => UnityEngine.Random.value;

    public float CalculateEffectiveDuration(float baseDuration, float qualityPercentage, float maxJitter = jitterMax)
    {
        float qualityFactor = Mathf.Clamp01((80f - qualityPercentage) / 100f);
        float timeMultiplier = 1f + qualityFactor * timePenaltyScale;
        float jitter = UnityEngine.Random.Range(-maxJitter, maxJitter);
        float effectiveDuration = baseDuration * timeMultiplier * (1f + jitter);
        return Mathf.Max(0.1f, effectiveDuration);
    }

    public float CalculateEffectiveFailChance(float baseFailChance, float qualityPercentage, float fatiguePenalty)
    {
        float maxFail = 0.75f;
        float qualityFactor = Mathf.Clamp01((80f - qualityPercentage) / 100f);
        float failAdd = qualityFactor * failPenaltyScale;
        float effectiveFail = baseFailChance + failAdd + fatiguePenalty;
        return Mathf.Clamp(effectiveFail, 0.01f, maxFail);
    }

    public float CalculateBreakChanceOnFail(float qualityPercentage)
    {
        return Mathf.Clamp(0.05f + (1f - qualityPercentage / 100f) * 0.6f, 0.05f, 0.6f);
    }
}