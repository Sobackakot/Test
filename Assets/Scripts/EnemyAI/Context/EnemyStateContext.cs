using EntityAI.Context;
using EntityAI;
using System;
using UnityEngine;

[Serializable] 
public class EnemyStateContext : IContext
{
    public EnemyStateContext(IEntity enemy)
    {
        this.enemy = enemy;
    }
    public event Action OnExecuteMoveAction;
    public IEntity enemy { get; set; }


    private bool _isIdle;
    public bool isIdle
    {
        get => _isIdle;
        private set
        {
            if (_isIdle == value) return;
            _isIdle = value;
            OnExecuteMoveAction?.Invoke();
        }
    }
    private bool _isRandomMove;
    public bool isRundomMove
    {
        get => _isRandomMove;
        private set
        {
            if (_isRandomMove == value) return;
            _isRandomMove = value;
            OnExecuteMoveAction?.Invoke();
        }
    }
    private bool _isRandomRotate;
    public bool isRandomRotate
    {
        get => _isRandomRotate;
        private set
        {
            if (_isRandomRotate == value) return;
            _isRandomRotate = value;
            OnExecuteMoveAction?.Invoke();
        }
    }


    private bool _isFollowTarget;
    public bool isFollowTarget
    {
        get => _isFollowTarget;
        private set
        {
            if (isFollowTarget == value) return;
            _isFollowTarget = value;
            OnExecuteMoveAction?.Invoke();
        }
    }
    private bool _isLoockTarget;
    public bool isLoockTarget
    {
        get => _isLoockTarget;
        private set
        {
            if (_isLoockTarget == value) return;
            _isLoockTarget = value;
            OnExecuteMoveAction?.Invoke();
        }
    }
    private bool _isAttackTarget;
    public bool isAttackTarget
    {
        get => _isAttackTarget;
        private set
        {
            if (_isAttackTarget == value) return;
            _isAttackTarget = value;
            OnExecuteMoveAction?.Invoke();
        }
    }
    public void UpdateContext()
    {
        TimerRoutine();
        isRundomMove = !isIdle && !isFollowTarget;
        isRandomRotate = !isLoockTarget;
        isLoockTarget = IsMinDistance(enemy.config.minDistanceLoockTarget);
        isAttackTarget = IsMinDistance(enemy.config.minDistanceAttackTarget);
        isFollowTarget = IsMinDistance(enemy.config.minDistanceFollowTarget);
    }
    private bool IsMinDistance(float minDistance)
    {
        return Vector3.Distance(enemy.components.tr.position, enemy.components.target.position) <= minDistance;
    }
    private void TimerRoutine()
    {
        timeAFC -= Time.deltaTime;
        if (timeAFC <= 0)
        {
            timeAFC = UnityEngine.Random.Range(3f, 10f);
            if (!isFollowTarget)
                IdleWaiteTime();
        }
    }
    private float time;
    [field: Range(1, 45), SerializeField] public float timeAFC { get; private set; } = 5f; 
    [field: Range(1, 45), SerializeField]  public float interval { get; private set; } = 5f;
    private void IdleWaiteTime()
    {
        isIdle = true;
        if(time < Time.time)
        {
            isIdle = false;
            time = Time.time + interval;
        } 
    }
}
 
