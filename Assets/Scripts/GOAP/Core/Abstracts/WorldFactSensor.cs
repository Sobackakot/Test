using UnityEngine;
using System.Collections.Generic;
using System;

// WorldFactSensor: Базовый класс для всех "датчиков" состояния мира.
public abstract class WorldFactSensor  
{
    public WorldFactSensor(AgentContext Context)
    {
        this.Context = Context;
    }
    protected AgentContext Context;

    protected virtual void Initializable()
    {
        // Сенсоры должны иметь доступ к контексту
        //Context = GetComponentInParent<AgentContext>();
    }

    // Абстрактный метод: Возвращает актуальный факт, если он TRUE, иначе null.
    // ЭТО И ЕСТЬ НАШ ЧИСТЫЙ АНАЛОГ IF/ELSE
    public abstract GOAPFact SenseFact();
}