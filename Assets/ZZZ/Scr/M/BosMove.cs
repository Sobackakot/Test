using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosMove : ZMoveBeh
{
    public bool isMinDistancePunchAttack = false;
    public bool isMinDistanceJumpAttack = false;

    public float minDistancePunchAttackTarget = 2;
    public float minDistanceJumpAttackTarget = 4;
    private void FixedUpdate()
    {
        if (isMinDistanceDefaultAttack || isMinDistancePunchAttack || isMinDistanceJumpAttack) return;
        LookTarget();
        FollowTarget();
    }
    public void Update()
    {
        isMinDistancePunchAttack = IsMinDistance(minDistancePunchAttackTarget);
        isMinDistanceJumpAttack = IsMinDistance(minDistanceJumpAttackTarget);
    }
    public override void FollowTarget()
    {
        base.FollowTarget();
    }
    public override void LookTarget()
    {
        base.LookTarget();
    }
    public override bool IsMinDistance(float minDistance)
    {
        return base.IsMinDistance(minDistance);
    }
}
