public interface IRandomizerService
{
    // Получает случайное число от 0.0 до 1.0.
    float GetRandomFloat();

    // Рассчитывает окончательную длительность действия с учетом качества инструмента и случайности.
    float CalculateEffectiveDuration(float baseDuration, float qualityPercentage, float maxJitter = 0.25f);

    // Рассчитывает окончательную вероятность провала с учетом базового шанса, качества и усталости.
    float CalculateEffectiveFailChance(float baseFailChance, float qualityPercentage, float fatiguePenalty);

    // Определяет вероятность поломки инструмента при провале.
    float CalculateBreakChanceOnFail(float qualityPercentage);
}