using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseDeadSpell : Spell
{
    public override void Create(Vector2 origin)
    {
        EnemyManager nearestTarget = CheckForTarget(origin);
        if(nearestTarget != null)
        {
            nearestTarget.RaiseFromDead("Player");
        }
    }

    public override EnemyManager CheckForTarget(Vector2 origin)
    {
        EnemyManager nearestTarget = null;

        foreach(EnemyManager enemyManager in FindObjectsOfType<EnemyManager>())
        {
            

            if(Vector2.Distance(enemyManager.transform.position, origin) <= range)
            {
                if(nearestTarget == null || Vector2.Distance(enemyManager.transform.position, origin) < Vector2.Distance(nearestTarget.transform.position, origin))
                {
                    Debug.Log(enemyManager.gameObject.name);
                    nearestTarget = enemyManager;
                }
            }

            enemyManager.selectedForRevive = false;
        }

        if(nearestTarget != null)
        {
            nearestTarget.selectedForRevive = true;
        }

        return nearestTarget;
    }
}
