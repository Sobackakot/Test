
using EnemyAi;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy data", menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    public Rigidbody enRb { get; private set; }
    public Transform enTr { get; private set; }
    public Transform tarTr { get; private set; }

    [Range(3, 30), SerializeField] public readonly float minDistanceLoockTarget = 30;
    [Range(3, 20), SerializeField] public readonly float minDistanceFollowTarget = 25;
    [Range(0.5f, 5), SerializeField] public readonly float minDistanceAttackTarget = 6;
    [Range(15, 45), SerializeField] public readonly float minAngle = 30f;
    [Range(60, 120), SerializeField] public readonly float maxAngle = 120f;
    [Range(3, 6), SerializeField] public readonly float speedMove = 5f;
    [Range(1, 45), SerializeField] public readonly float angleRotate = 3f;
    public void SetTarget(Transform tarTr)
    {
        this.tarTr = tarTr;
    }
    public void SetRigidbody(Rigidbody enRb)
    {
        this.enRb = enRb;
    }
    public void SetTransform(Transform enTr)
    {
        this.enTr = enTr;
    }
}
