using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDeadState : AIState
{
    public GoblinIdleState idleState;
    public override AIState Tick(EnemyManager enemyManager, AnimationManager enemyAnimationManager)
    {
        if (enemyManager.selectedForRevive)
        {
            enemyManager.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            enemyManager.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        }
        
        if(enemyManager.characterStats.CurrentHP > 0)
        {
            enemyManager.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            return idleState;
        }
        else
        {
            return this;
        }
    }
}
