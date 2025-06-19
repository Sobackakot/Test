using System;
using UnityEngine;

public class ZAttackBeh : MonoBehaviour
{
    public event Action onDefaultAttack; 
    public CharacterMove target { get; private set; }
    public ZStateMachine zStateMachine { get; private set; }
    public ZMoveBeh moveZ { get; private set; } 
     
    protected bool isAttackTarget { get; set; } = true;

    public float damage;
    public float defaultDamage { get; private set; } = 10;

    public float timer { get; set; } = 0;

    private void Awake()
    {
        target = FindObjectOfType<CharacterMove>(); 
        zStateMachine = GetComponent<Animator>().GetBehaviour<ZStateMachine>();
        moveZ = GetComponent<ZMoveBeh>();
    }
    private void OnEnable()
    {
        zStateMachine.onStartAttackAnim += StartAnimAttack;
        zStateMachine.onEndAttackAnim += EndAnimAttack;
    }
    private void OnDisable()
    {
        zStateMachine.onStartAttackAnim -= StartAnimAttack;
        zStateMachine.onEndAttackAnim -= EndAnimAttack;
    }
    private void Update()
    {
        ThresholdAttack();
    }
    public virtual void ThresholdAttack()
    {
        if (moveZ.IsMinDistance(moveZ.minDistanceDefaultAttackTarget)&& isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damage = defaultDamage;
            onDefaultAttack?.Invoke();
        }
    }
    public virtual void TakeDamage()
    {
        if (moveZ.isMinDistanceDefaultAttack)
        {
            target.TakeDamage(damage);
        }
        zStateMachine.onTakeDamage -= TakeDamage;
    }

    public virtual void StartAnimAttack()
    {
        isAttackTarget = false;
        zStateMachine.onTakeDamage += TakeDamage;
    }
    public virtual void EndAnimAttack()
    {
        isAttackTarget = true;
    }
}
