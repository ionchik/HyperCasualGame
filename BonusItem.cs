using UnityEngine;
using System;

public class BonusItem
{
    // Типы бонусов
    public enum BonusType
    {
        Speed,
        Score,
        Health
    }

    // Свойства бонуса
    public BonusType Type { get; private set; }
    public int Value { get; private set; }
    public float Duration { get; private set; } // Длительность эффекта (в секундах)

    // Событие для обработки активации бонуса
    public static event Action<BonusType, int, float> OnBonusActivated;

    // Конструктор
    public BonusItem(BonusType type, int value, float duration)
    {
        Type = type;
        Value = value;
        Duration = duration;
    }

    // Метод для активации бонуса
    public void Activate()
    {
        Debug.Log($"Bonus of type {Type} activated with value {Value} for {Duration} seconds.");
        OnBonusActivated?.Invoke(Type, Value, Duration);
    }
}
