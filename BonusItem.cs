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
    private bool isActive; // Флаг активности бонуса

    // События
    public static event Action<BonusType, int, float> OnBonusActivated;
    public static event Action<BonusType> OnBonusCancelled;

    // Конструктор
    public BonusItem(BonusType type, int value, float duration)
    {
        Type = type;
        Value = value;
        Duration = duration;
        isActive = false;
    }

    // Метод для активации бонуса
    public void Activate()
    {
        if (isActive)
        {
            Debug.LogWarning("Bonus is already active!");
            return;
        }

        isActive = true;
        Debug.Log($"Bonus of type {Type} activated with value {Value} for {Duration} seconds.");
        OnBonusActivated?.Invoke(Type, Value, Duration);
    }

    // Метод для отмены бонуса
    public void Cancel()
    {
        if (!isActive)
        {
            Debug.LogWarning("Bonus is not active and cannot be cancelled!");
            return;
        }

        isActive = false;
        Debug.Log($"Bonus of type {Type} has been cancelled.");
        OnBonusCancelled?.Invoke(Type);
    }
}
