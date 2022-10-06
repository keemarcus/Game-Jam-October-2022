using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSlot : MonoBehaviour
{
    [Header("Spell Attributes")]
    public GameObject spellPrefab;
    public string spellAnimation;
    public Spell spellScript;
    //private GameObject caster;

    private void Awake()
    {
        //spellScript = spellPrefab.GetComponent<Spell>();
        //if(spellScript == null)
        {
            //Debug.Log("No script found for spell " + spellPrefab.name);
        }

        //caster = this.gameObject;
        //if(caster.GetComponent<PlayerManager>() == null)
        {
            //Debug.Log("No player manager found for spellcaster " + this.gameObject.name);
        }  
    }

    public void Cast(Vector2 origin, GameObject caster)
    {
        if(spellScript.gameObject.GetComponent<SummonSpell>() != null)
        {
            spellScript.gameObject.GetComponent<SummonSpell>().creaturePrefab = this.spellPrefab;
        }
        spellScript.Create(origin, caster);
    }
}
