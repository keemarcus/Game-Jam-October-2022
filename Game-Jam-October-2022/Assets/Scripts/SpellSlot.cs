using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSlot : MonoBehaviour
{
    [Header("Spell Attributes")]
    public GameObject spellPrefab;
    public string spellAnimation;
    public Spell spellScript;

    public void Cast(Vector2 origin, GameObject caster)
    {
        if(spellScript.gameObject.GetComponent<SummonSpell>() != null)
        {
            spellScript.gameObject.GetComponent<SummonSpell>().creaturePrefab = this.spellPrefab;
        }
        spellScript.Create(origin, caster);
    }
}
