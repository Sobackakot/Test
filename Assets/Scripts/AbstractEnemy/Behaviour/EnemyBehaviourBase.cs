using EnemyAi; 
using UnityEngine; 
public abstract class EnemyBehaviourBase :
        IEnemyIdle,
        IEnemyMove,
        IEnemyRotate,
        IEnemyRandoMove,
        IEnemyRandomRotate,
        IEnemyFollowTarget,
        IEnemyLoockTarget,
        IEnemyAttackTarget
{ 
    public EnemyBehaviourBase(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public Enemy enemy { get; private set; }
    public virtual void IdleState()
    { 
    } 
    public virtual void Moving(Vector3 targetMove)
    { 
    } 
    public virtual void Rotating(Quaternion targetRotation)
    { 
    } 
    public virtual void RandomMove()
    { 
    } 
    public virtual void RandomRotate()
    { 
    } 
    public virtual void FollowTarget()
    { 
    } 
    public virtual void LoockTarget()
    {
         
    } 
    public virtual void AttackTarget()
    { 
    }
}
