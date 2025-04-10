
using EnemyAi;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy data", menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; }
    [field: SerializeField] public EnemyType EnemyType { get; private set; }

    [field: Range(3, 30), SerializeField] public float minDistanceLoockTarget { get; private set; } = 30;
    [field: Range(3, 20), SerializeField] public float minDistanceFollowTarget { get; private set; } = 25;
    [field: Range(0.5f, 5), SerializeField] public float minDistanceAttackTarget { get; private set; } = 6;
    [field: Range(15, 45), SerializeField] public float minAngle { get; private set; } = 30f;
    [field: Range(60, 120), SerializeField] public float maxAngle { get; private set; } = 120f;
    [field: Range(3, 6), SerializeField] public  float speedMove { get; private set; } = 5f;
    [field: Range(1, 45), SerializeField] public float angleRotate { get; private set; } = 3f;

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
