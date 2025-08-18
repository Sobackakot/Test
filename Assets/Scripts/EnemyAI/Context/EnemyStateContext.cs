using EntityAI;
using EntityAI.Context;
using System;
using UnityEngine;

[Serializable] 
public class EnemyStateContext : EntityAI.Context.EntityAI
{
    public EnemyStateContext(IEntity enemy)
    {
        this.enemy = enemy;
    }
    public event Action OnExecuteMoveAction;
    public IEntity enemy { get; set; }

    bool _isHasTarget =false;
    public bool isHasTarget => _isHasTarget;

    bool _isInAttackRange =false;
    public bool isInAttackRange => _isInAttackRange;


    public bool _isHasInteract = false;
    public bool isHasInteract => _isHasInteract;

    public bool _isFocus = false;
    public bool isFocus => _isFocus;
    public void SetStateTarget()
    {
        _isHasTarget = true; 
    }
    public void ResetStateTarget()
    {
        _isHasTarget = false; 
    }

    bool _isHasRaycastHitTarget = false;
    public bool isHasRaycastHitTarget
    {
        get => _isHasRaycastHitTarget;
        private set
        {
            if (_isHasRaycastHitTarget == value) return;
            _isHasRaycastHitTarget = value;
            OnExecuteMoveAction?.Invoke();
        }
    }

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
        _isInAttackRange = isAttackTarget;
    }

    private bool IsMinDistance(float minDistance)
    { 
        return Vector3.Distance(enemy.components.trEntity.position, enemy.components.trTarget.position) <= minDistance; 
    }
    private void TimerRoutine()
    {
        var timer = enemy.config.timeAFC;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = UnityEngine.Random.Range(3f, 10f);
            if (!isFollowTarget)
                IdleWaiteTime();
        }
    } 
     
    private void IdleWaiteTime()
    {
        var time = enemy.config.time;
        isIdle = true;
        if(time < Time.time)
        {
            isIdle = false;
            time = Time.time + enemy.config.interval;
        } 
    } 

}
 
