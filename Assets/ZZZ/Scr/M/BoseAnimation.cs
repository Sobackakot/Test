using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoseAnimation : ZAnimation
{

    private BoseAttack attackMutant;
    private void Awake()
    {
        attackMutant = GetComponent<BoseAttack>();
    }
    private void OnEnable()
    {
        attackMutant.onAttack += DefaultAttackAnim;
        attackMutant.onPunchAttack += PunchAnimAttack;
        attackMutant.onJumpAttack += JumpAnimAttack;
        attackMutant.onTakeAttackPerson += TakePersonHand;
    }
    private void OnDisable()
    {
        attackMutant.onAttack -= DefaultAttackAnim;
        attackMutant.onPunchAttack -= PunchAnimAttack;
        attackMutant.onJumpAttack -= JumpAnimAttack;
        attackMutant.onTakeAttackPerson -= TakePersonHand;
    }
    private void TakePersonHand()
    {
        animZ.SetTrigger("TakePersonTrigger");
    }
}
