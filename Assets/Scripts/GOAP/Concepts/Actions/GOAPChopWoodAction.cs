using UnityEngine;

public class GOAPChopWoodAction : GOAPAction
{
    public GOAPChopWoodAction(AgentContext Context) : base(Context)
    {
    }
    private float chopDuration = 2.0f; // Время, необходимое для рубки
    private float startTime = 0f;

  

    public override void SetupAction()
    {
        // ПРЕДУСЛОВИЕ: Агент должен иметь топор (HasAxeTool).
        AddPrecondition(new HasAxeFact(true));

        // ЭФФЕКТ: Агент получает дрова (HasWood).
        AddEffect(new HasWoodFact(true));

        cost = 3.0f; // Рубка требует больше энергии, чем еда
    }

    public override bool CheckProceduralPrecondition()
    {
        // Проверка: Находится ли агент рядом с деревом или в зоне добычи.
        // Для абстрактной системы: всегда true, если есть топор.
        return Context.HasAxeTool;
    }

    public override bool Perform()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
            Debug.Log($"[{GetActionName()}]: Начало рубки. Потребуется {chopDuration} сек.");
        }

        // --- Логика Выполнения ---
        if (Time.time - startTime >= chopDuration)
        {
            // Успех: Изменяем контекст мира
            Context.HasWood = true;
            Context.CurrentEnergy -= cost * 10f; // Тратим много энергии

            Debug.Log($"[{GetActionName()}]: Рубка завершена! Получены дрова. Энергия: {Context.CurrentEnergy:F1}");
            return true; // Действие завершено
        }

        return false; // Действие продолжается
    }

    public override bool IsActionFinished()
    {
        // Завершение проверяется внутри Perform
        return !isRunning && Context.HasWood;
    }

    public override void Reset()
    {
        isRunning = false;
        startTime = 0f;
    }
}
