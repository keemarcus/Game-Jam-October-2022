using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSpell : Spell
{
    public override void Create(Vector2 origin)
    {
        var spellAngle = Mathf.Atan2(this.gameObject.GetComponent<PlayerManager>().aimDirection.x * -1, this.gameObject.GetComponent<PlayerManager>().aimDirection.y) * Mathf.Rad2Deg;
        GameObject newCreature = Instantiate(spellPrefab, origin + (this.gameObject.GetComponent<PlayerManager>().aimDirection * range), Quaternion.identity);
    }
}
