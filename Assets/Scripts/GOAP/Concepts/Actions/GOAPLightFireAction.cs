using UnityEngine;

// Действие: Разжечь огонь
public class GOAPLightFireAction : GOAPAction
{ 
    public GOAPLightFireAction(AgentContext Context) : base(Context)
    {
    }
    private float lightDuration = 1.5f;
    private float startTime = 0f;
    public override void SetupAction()
    {
        // ПРЕДУСЛОВИЕ: Должны быть дрова.
        AddPrecondition(new HasWoodFact(true));
        // ПРЕДУСЛОВИЕ: Огонь НЕ должен гореть.
        AddPrecondition(new IsFireLitFact(false));

        // ЭФФЕКТ: Огонь горит. Дрова потрачены.
        AddEffect(new IsFireLitFact(true));
        AddEffect(new HasWoodFact(false)); // Дрова потрачены

        cost = 1.5f;
    }

    public override bool CheckProceduralPrecondition()
    {
        // Проверка: Находится ли агент у места для костра и есть ли спички/зажигалка.
        // Для абстрактной системы: true, если дрова есть и костер не горит.
        return Context.HasWood && !Context.IsFireLit;
    }

    public override bool Perform()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
            Debug.Log($"[{GetActionName()}]: Начало разжигания костра...");
        }

        // --- Логика Выполнения ---
        if (Time.time - startTime >= lightDuration)
        {
            // Успех: Изменяем контекст мира
            Context.IsFireLit = true;
            Context.HasWood = false; // Дрова сгорели
            Context.CurrentEnergy -= cost * 5f; // Небольшая трата энергии

            Debug.Log($"[{GetActionName()}]: Костер разгорелся! Дрова потрачены. Энергия: {Context.CurrentEnergy:F1}");
            return true; // Действие завершено
        }

        return false; // Действие продолжается
    }

    public override bool IsActionFinished()
    {
        // Завершение проверяется внутри Perform
        return !isRunning && Context.IsFireLit;
    }

    public override void Reset()
    {
        isRunning = false;
        startTime = 0f;
    }
}