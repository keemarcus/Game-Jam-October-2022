using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : MonoBehaviour
{
    public abstract AIState Tick(EnemyManager enemyManager, AnimationManager enemyAnimationManager);
}
