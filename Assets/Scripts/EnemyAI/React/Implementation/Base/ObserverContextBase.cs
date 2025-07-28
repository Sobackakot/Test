using System;
using System.Collections.Generic;

namespace EntityAI.React
{
    public abstract class ObserverContextBase<TEnum> :
    IObserverContext<TEnum> where TEnum : Enum
    {
        public ObserverContextBase(IActionSubject<TEnum, IObserverContext<TEnum>> subject)
        {
            this.subject = subject;
        }

        protected readonly Dictionary<TEnum, Delegate> _reactionMap = new();
        protected IReadOnlyDictionary<TEnum, Delegate> reactionMap => _reactionMap;

        protected readonly IActionSubject<TEnum, IObserverContext<TEnum>> subject;
         
        protected void Register(TEnum ctxType, Action handler)
        {
            _reactionMap[ctxType] = handler;
        }

        protected void Register<T>(TEnum ctxType, Action<T> handler)
        {
            _reactionMap[ctxType] = handler;
        }

        protected void Register<T1, T2>(TEnum ctxType, Action<T1, T2> handler)
        {
            _reactionMap[ctxType] = handler;
        }

        protected void Register<TResult>(TEnum ctxType, Func<TResult> handler)
        {
            _reactionMap[ctxType] = handler;
        }

        protected void Register<T, TResult>(TEnum ctxType, Func<T, TResult> handler)
        {
            _reactionMap[ctxType] = handler;
        }

        protected void Register<T1, T2, TResult>(TEnum ctxType, Func<T1, T2, TResult> handler)
        {
            _reactionMap[ctxType] = handler;
        }
         

        public void ReactionOnAction(TEnum ctxType)
        {
            if (reactionMap.TryGetValue(ctxType, out var dlgate) && dlgate is Action typedAction)
            {
                typedAction?.Invoke();
            }
        }

        public void ReactionOnAction<T>(TEnum ctxType, T value)
        {
            if (reactionMap.TryGetValue(ctxType, out var dlgate) && dlgate is Action<T> typedAction)
            {
                typedAction?.Invoke(value);
            }
        }

        public void ReactionOnAction<T1, T2>(TEnum ctxType, T1 value1, T2 value2)
        {
            if (reactionMap.TryGetValue(ctxType, out var dlgate) && dlgate is Action<T1, T2> typedAction)
            {
                typedAction?.Invoke(value1, value2);
            }
        }

        public TResult ReactionOnAction<TResult>(TEnum ctxType)
        {
            if (reactionMap.TryGetValue(ctxType, out var dlgate) && dlgate is Func<TResult> typedFunc)
            {
                return typedFunc.Invoke();
            }
            throw new InvalidOperationException(
                $"No handler registered for {ctxType} or handler type mismatch for Func<TResult>.");
        }

        public TResult ReactionOnAction<T, TResult>(TEnum ctxType, T value)
        {
            if (reactionMap.TryGetValue(ctxType, out var dlgate) && dlgate is Func<T, TResult> typedFunc)
            {
                return typedFunc.Invoke(value);
            }
            throw new InvalidOperationException(
                $"No handler registered for {ctxType} or handler type mismatch for Func<T, TResult>.");
        }

        public TResult ReactionOnAction<T1, T2, TResult>(TEnum ctxType, T1 value1, T2 value2)
        {
            if (reactionMap.TryGetValue(ctxType, out var dlgate) && dlgate is Func<T1, T2, TResult> typedFunc)
            {
                return typedFunc.Invoke(value1, value2);
            }
            throw new InvalidOperationException(
                $"No handler registered for {ctxType} or handler type mismatch for Func<T1, T2, TResult>.");
        }

        protected void SubscribeAll()
        {
            foreach (var key in _reactionMap)
                subject.Subscribe(key.Key, this);
        }

        protected void UnsubscribeAll()
        {
            foreach (var key in _reactionMap)
                subject.Unsubscribe(key.Key, this);
        }
    }  
}