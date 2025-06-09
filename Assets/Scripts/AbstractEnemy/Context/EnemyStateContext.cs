using System;

[Serializable] 
public class EnemyStateContext  
{
    public event Action OnExecuteMoveAction;
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
        get => _isFollowTarget;
        private set
        {
            if (_isFollowTarget == value) return;
            _isFollowTarget = value;
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

}
 
