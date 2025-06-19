using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZMoveBeh : MonoBehaviour
{
    private CharacterMove state;
    private ZStateMachine stateEnemy;

    private Transform transChar;
    private Transform transEnemy;
    private Rigidbody rigEnemy;

    private Animator animatorZ;

    private ZAnimation animZ;
    public float speedFollow = 5;
    public float speedRotate = 2;

    public float distance;
    public float minDistanceFollowTarget = 15;
    public float minDistanceLookTarget = 25;
    public float minDistanceDefaultAttackTarget = 1;
    [Header("State - Idle, Screamer begin true")]
    public bool isIdle = true;
    public bool isScreamer = true;
    public bool isLookTarget = false;
    public bool isFollowTarget = false;
    public bool isMinDistanceDefaultAttack = false;

    public event Action onScream;
    public event Action onPlayAudioZombieScreamer;
    private void Awake()
    {
        state = FindObjectOfType<CharacterMove>();
        animatorZ = GetComponent<Animator>();
        stateEnemy = animatorZ.GetBehaviour<ZStateMachine>();
        transChar = FindObjectOfType<CharacterMove>().transform;
        transEnemy = GetComponent<Transform>();
        rigEnemy = GetComponent<Rigidbody>();
        animZ = GetComponent<ZAnimation>();
    }
    private void OnEnable()
    {
        isScreamer = true;
    }
    private void FixedUpdate()
    {
        if (isMinDistanceDefaultAttack) return;
        LookTarget();
        FollowTarget();
    }
    private void Update()
    {
        isFollowTarget = IsMinDistance(minDistanceFollowTarget);
        isLookTarget = IsMinDistance(minDistanceLookTarget);
        isMinDistanceDefaultAttack = IsMinDistance(minDistanceDefaultAttackTarget);
        if (isScreamer && isLookTarget)
        {
            StartCoroutine(ScreamWaitTime());
        }
    }
    private IEnumerator ScreamWaitTime()
    {
        onScream?.Invoke();
        onPlayAudioZombieScreamer?.Invoke(); 
        isIdle = true;
        yield return new WaitForSeconds(2.3f);
        isIdle = false;
        isScreamer = false;
    }
    public virtual void FollowTarget()
    {
        if (isFollowTarget && !isScreamer && !isIdle)
        {
            animZ.MoveAnim(1);
            Move(transform.forward);
        }
    }
    public virtual bool IsMinDistance(float minDistance)
    {
        distance = Vector3.Distance(transEnemy.position, transChar.position);
        if (distance <= minDistance)
            return true;
        else return false;
    }
    public virtual void LookTarget()
    {
        if (isFollowTarget && IsMinDistance(minDistanceLookTarget))
        {
            Vector3 direction = (transChar.position - transEnemy.position).normalized;
            Quaternion rotate = Quaternion.LookRotation(direction, Vector3.up);
            Rotate(rotate);
        }
    }
    public void Move(Vector3 position)
    {
        rigEnemy.MovePosition(rigEnemy.position + position * speedFollow * Time.fixedDeltaTime);
    }
    public void Rotate(Quaternion direction)
    {
        Quaternion smoothRotate = Quaternion.Slerp(transEnemy.rotation, direction, Time.fixedDeltaTime * speedRotate);
        rigEnemy.MoveRotation(smoothRotate);
    }
}
