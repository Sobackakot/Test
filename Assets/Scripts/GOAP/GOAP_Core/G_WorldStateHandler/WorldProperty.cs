using System;

namespace EntityAI.GOAP.WorldState
{
    public abstract class WorldProperty<T> : IWorldProperty
    {
        public T Value;

        public WorldProperty() { }
        public WorldProperty(T v) { Value = v; }

        public virtual IWorldProperty Clone()
        {
            // Использует reflection для создания копии и установки значения.
            var inst = (WorldProperty<T>)Activator.CreateInstance(this.GetType());
            inst.Value = Value;
            return inst;
        }

        public object GetValue() => Value;
        public void SetValue(object v) => Value = (T)v;
    }
}