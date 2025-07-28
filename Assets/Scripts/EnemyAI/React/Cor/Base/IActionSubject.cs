using System;

namespace EntityAI.React 
{
    public interface IActionSubject<TEnum, IObserver>
        where TEnum : Enum
        where IObserver : class, IObserverContext<TEnum>
    { 
        void InvokeAction(TEnum dataType);
         
        void InvokeAction<T>(TEnum dataType, T value);
         
        void InvokeAction<T1, T2>(TEnum dataType, T1 value1, T2 value2);
         
        TResult InvokeAction<TResult>(TEnum dataType);
         
        TResult InvokeAction<T, TResult>(TEnum dataType, T value);
         
        TResult InvokeAction<T1, T2, TResult>(TEnum dataType, T1 value1, T2 value2);
         
        void Subscribe(TEnum dataType, IObserver observerCtx);
        void Unsubscribe(TEnum dataType, IObserver observerCtx);
        void ToggleBool(TEnum dataType, bool defaultValue);
    }
}


