using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float range;
    //public GameObject spellPrefab;
    //public string spellAnimation;

    abstract public void Create(Vector2 origin, GameObject caster);

    abstract public EnemyManager CheckForTarget(Vector2 origin);
}
