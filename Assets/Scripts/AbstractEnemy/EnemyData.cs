
using EnemyAi;
using System;
using UnityEngine;

[Serializable] 
public class EnemyData  
{
    [field: SerializeField] public bool isIdle { get; private set; }
    [field: SerializeField] public bool isRundomMove { get; private set; }
    [field: SerializeField] public bool isRundomRotate { get; private set; }
    [field: SerializeField] public bool isFollowTarget { get; private set; }
    [field: SerializeField] public bool isLoockTarget { get; private set; }
    [field: SerializeField] public bool isAttackTarget { get; private set; }

}
public enum EnemyType
{
    Default,
    Fire,
    Freez,
    Ellectr,
    Woter,
    Air,
    None
}
