using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentContext : MonoBehaviour
{
    // --- Потребности ---
    public float CurrentHunger = 50f; // Уровень голода
    public float CurrentEnergy = 100f; // Запас энергии

    // --- Ресурсы/Состояния (будут использоваться GOAP-фактами) ---
    public bool HasRawFood = false; // Наличие сырой еды
    public bool HasAxeTool = false; // Наличие топора
    public bool HasWood = false; // Наличие дров
    public bool IsFireLit = false; // Горит ли костер

    // Метод для определения, голоден ли персонаж (логика "голоден" для GOAP)
    public bool IsCharacterHungry()
    {
        return CurrentHunger < 20f; // Порог голода
    }

    private void Update()
    {
        // Имитация расхода ресурсов (пока в абстрактном режиме)
        CurrentEnergy -= Time.deltaTime * 0.5f;
        CurrentHunger -= Time.deltaTime * 0.1f;
        CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0f, 100f);
        CurrentHunger = Mathf.Clamp(CurrentHunger, 0f, 100f);

        if (IsCharacterHungry())
        {
            Debug.LogWarning($"[Context]: Персонаж голоден! Hunger: {CurrentHunger:F1}");
        }
    }
}
