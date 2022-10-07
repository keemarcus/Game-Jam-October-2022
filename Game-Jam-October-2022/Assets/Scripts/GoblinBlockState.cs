using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBlockState : AIState
{
    public override AIState Tick(EnemyManager enemyManager, AnimationManager enemyAnimationManager)
    {
        enemyAnimationManager.animator.SetBool("Blocking", true);
        return this;
    }
}
