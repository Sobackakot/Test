using EntityAI;
using EntityAI.Config;
using EntityAI.Factory;
using UnityEngine;



namespace EntityAI.Creator
{
    public interface ICreator  
    {
        PoolSystem pool { get;}
        void Creating(IFactory factory);
        void CreatingPool(GameObject prefab, EntityType type, int count, Vector3 pos, Quaternion rot);
    }
}