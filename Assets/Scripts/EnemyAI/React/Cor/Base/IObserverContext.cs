using System;

namespace EntityAI.React
{
    public interface IObserverContext<TEnum>
        where TEnum : Enum
    { 
        void ReactionOnAction(TEnum dataType); 
        void ReactionOnAction<T>(TEnum dataType, T value);
         
        void ReactionOnAction<T1, T2>(TEnum dataType, T1 value1, T2 value2);
         
        TResult ReactionOnAction<TResult>(TEnum dataType);
         
        TResult ReactionOnAction<T, TResult>(TEnum dataType, T value);
         
        TResult ReactionOnAction<T1, T2, TResult>(TEnum dataType, T1 value1, T2 value2);
    }
}