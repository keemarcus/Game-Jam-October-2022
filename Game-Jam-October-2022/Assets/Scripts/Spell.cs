using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float range;
    public GameObject spellPrefab;

    abstract public void Create(Vector2 origin);
}
