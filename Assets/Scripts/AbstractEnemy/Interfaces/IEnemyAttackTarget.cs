 
using UnityEngine;


namespace EnemyAi
{
    public interface IEnemyAttackTarget
    {
        bool isAttackTarget { get; set; }
        void AttackTarget();
    }

}
