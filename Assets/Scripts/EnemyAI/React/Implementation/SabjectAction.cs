using System;
using System.Collections.Generic;

namespace EntityAI.React
{
    public abstract class SabjectAction<TEnum, IObserver> :
        IActionSubject<TEnum, IObserver>
        where TEnum : Enum
        where IObserver : class, IObserverContext<TEnum>
    {
        private readonly Dictionary<TEnum, List<IObserver>> _observers = new();
        private readonly Dictionary<TEnum, bool> _boolToggles = new();

        public void Subscribe(TEnum dataType, IObserver observerCtx)
        {
            if (!_observers.ContainsKey(dataType))
                _observers[dataType] = new List<IObserver>();
            if (!_observers[dataType].Contains(observerCtx))
                _observers[dataType].Add(observerCtx);
        }

        public void Unsubscribe(TEnum dataType, IObserver observerCtx)
        {
            if (_observers.TryGetValue(dataType, out var list))
            {
                list.Remove(observerCtx);
                if (list.Count == 0)
                    _observers.Remove(dataType);
            }
        }

        // --- Методы InvokeAction для различных сигнатур ---

        public void InvokeAction(TEnum dataType)
        {
            if (_observers.TryGetValue(dataType, out var list))
            {
                foreach (var observer in list)
                    observer?.ReactionOnAction(dataType);
            }
        }

        public void InvokeAction<T>(TEnum dataType, T value)
        {
            if (_observers.TryGetValue(dataType, out var list))
            {
                foreach (var observer in list)
                    observer?.ReactionOnAction(dataType, value);
            }
        }

        public void InvokeAction<T1, T2>(TEnum dataType, T1 value1, T2 value2)
        {
            if (_observers.TryGetValue(dataType, out var list))
            {
                foreach (var observer in list)
                    observer?.ReactionOnAction(dataType, value1, value2);
            }
        }

        public TResult InvokeAction<TResult>(TEnum dataType)
        {
            if (_observers.TryGetValue(dataType, out var list) && list.Count > 0)
            {
                // Для методов с возвращаемым значением, если несколько наблюдателей,
                // берем результат от первого. Вам может понадобиться другая логика.
                return list[0].ReactionOnAction<TResult>(dataType);
            }
            throw new InvalidOperationException(
                $"No subscriber found for {dataType} or signature does not match handler for Func<TResult>.");
        }

        public TResult InvokeAction<T, TResult>(TEnum dataType, T value)
        {
            if (_observers.TryGetValue(dataType, out var list) && list.Count > 0)
            {
                return list[0].ReactionOnAction<T, TResult>(dataType, value);
            }
            throw new InvalidOperationException(
            $"No subscriber found for {dataType} or signature does not match handler for Func<T1,TResult>.");
        }

        public TResult InvokeAction<T1, T2, TResult>(TEnum dataType, T1 value1, T2 value2)
        {
            if (_observers.TryGetValue(dataType, out var list) && list.Count > 0)
            {
                return list[0].ReactionOnAction<T1, T2, TResult>(dataType, value1, value2);
            }
            throw new InvalidOperationException(
            $"No subscriber found for {dataType} or signature does not match handler for Func<T1, T2, TResult>.");
        }

        public void ToggleBool(TEnum dataType, bool defaultValue)
        {
            if (!_boolToggles.ContainsKey(dataType))
                _boolToggles[dataType] = defaultValue;
            bool current = _boolToggles.TryGetValue(dataType, out var value) ? value : default;
            bool toggle = !current;
            _boolToggles[dataType] = toggle;
            InvokeAction(dataType, toggle);  
        }
    }
    public enum EntityActionType
    { 
        EntityReg,
        EntityUnreg
    }
    public enum StateMachineActionType
    {
        StateMachineReg,
        StateMachineUnreg,
        SetState
    }
    public enum BehaviourHandlerActionType 
    { 
        BehaviourHandlerReg,
        BehaviourHandlerUnreg
    }
    public enum PlanerActionType
    {
        PlanerReg,
        PlanerUnreg,
        Subscribe,
        Unsibsribe
    }
    public enum CreatorActionType
    {
        Creator
    }

}

