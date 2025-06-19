using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoseHP :ZHP
{
    public override void TakeDamageEnemy(float damage)
    {
        if (currentHP <= 0)
        {
            anim.SetTrigger("DeathTrigger");
            InactiveZombie(false);
        }
        else
        {
            currentHP -= damage / ignoreDamage;
        }
    }
}
