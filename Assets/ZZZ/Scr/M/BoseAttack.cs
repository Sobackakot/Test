using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoseAttack : ZAttackBeh
{
    public event Action onAttack;
    public event Action onPunchAttack;
    public event Action onJumpAttack;
    public event Action onTakeAttackPerson;

    private Transform originalParent;
    private BosMove move; 
    private BosStateMachine bosStateMachine;

    private Rigidbody rbPerson;
    private Transform trPerson;
    private Collider clPerson;

    public bool isTakePerson = false;

    public Transform trMutantHand;

    public float punchDamage = 15;
    public float jumpDamage = 25; 

    private void Awake()
    {  
        move = GetComponent<BosMove>();
        bosStateMachine = GetComponent<Animator>().GetBehaviour<BosStateMachine>();
        trPerson = FindObjectOfType<CharacterMove>().transform;
        rbPerson = FindObjectOfType<CharacterMove>().GetComponent<Rigidbody>();
        clPerson = FindObjectOfType<CharacterMove>().GetComponent<Collider>();
    } 
    private void OnEnable()
    {
        bosStateMachine.onStartAttackAnim += StartAnimAttack;
        bosStateMachine.onEndAttackAnim += EndAnimAttack;
        bosStateMachine.onStartTakeAttackAnim += OnStartTakeAttack;
        bosStateMachine.onEndTakeAttackAnim += OnEndTakeAttack;
 
    }
    private void OnDisable()
    {
        bosStateMachine.onStartAttackAnim -= StartAnimAttack;
        bosStateMachine.onEndAttackAnim -= EndAnimAttack;
        bosStateMachine.onStartTakeAttackAnim -= OnStartTakeAttack;
        bosStateMachine.onEndTakeAttackAnim -= OnEndTakeAttack;
    }
    private void Update()
    {
        ThresholdAttack();
        if (isTakePerson)
        {
            AttackTakePerson();
            isTakePerson = false;
        }
    }
    public override void ThresholdAttack()
    {
        if (move.IsMinDistance(move.minDistanceDefaultAttackTarget) && moveZ.IsMinDistance(move.minDistancePunchAttackTarget) && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damage = defaultDamage;
            onAttack?.Invoke();
            Debug.Log("Default");
        }
        else if (move.IsMinDistance(move.minDistancePunchAttackTarget) && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damage = punchDamage;
            onPunchAttack?.Invoke();
            Debug.Log("Punch");
        }
        else if (move.IsMinDistance(move.minDistanceJumpAttackTarget) && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damage = jumpDamage;
            onJumpAttack?.Invoke();
            Debug.Log("Jump");
        }
    }
    private void AttackTakePerson()
    {
        originalParent = trPerson.parent;
        trPerson.SetParent(trMutantHand);
        Debug.Log("TakePerson " + trPerson.name);
        onTakeAttackPerson?.Invoke();
    }
    private void OnStartTakeAttack()
    {
        rbPerson.isKinematic = true;
        clPerson.enabled = false; 
    }
    private void OnEndTakeAttack()
    {
        trPerson.SetParent(originalParent); 
        rbPerson.isKinematic = false;
        clPerson.enabled = true;
        isTakePerson = false;
    }
    public override void TakeDamage()
    {
        if(move.isMinDistanceDefaultAttack)
        {
            target.TakeDamage(damage);
        }
        bosStateMachine.onTakeDamage -= TakeDamage;
    }
    public override void StartAnimAttack()
    {
        isAttackTarget = false;
        bosStateMachine.onTakeDamage += TakeDamage;
    }
    public override void EndAnimAttack()
    { 
        isAttackTarget = true;
    }
}
