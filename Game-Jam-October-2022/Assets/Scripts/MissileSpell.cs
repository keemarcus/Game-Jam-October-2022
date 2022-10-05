using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpell : Spell
{
    [Header("Spell Attributes")]
    public float missileSpeed;
    public string spellType;
    public int spellEffectAmount;
    public string spellEffectType;

    public override void Create(Vector2 origin)
    {
        var spellAngle = Mathf.Atan2(this.gameObject.GetComponent<PlayerManager>().aimDirection.x * -1, this.gameObject.GetComponent<PlayerManager>().aimDirection.y) * Mathf.Rad2Deg;
        GameObject newSpell = Instantiate(spellPrefab, origin, Quaternion.AngleAxis(spellAngle, Vector3.forward));
        newSpell.GetComponent<Rigidbody2D>().freezeRotation = true;
        newSpell.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<PlayerManager>().aimDirection * missileSpeed;
        Physics2D.IgnoreCollision(newSpell.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        //newSpell.GetComponent<ParticleSystem>().Play();
        MissileSpell spellScript = newSpell.AddComponent<MissileSpell>();
        //spellScript.missileSpeed = this.missileSpeed;
        spellScript.spellType = this.spellType;
        spellScript.spellEffectAmount = this.spellEffectAmount;
        spellScript.spellEffectType = this.spellEffectType;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // look for charcters that we hit
        //Debug.Log(collision.gameObject.name);
        CharacterManager hitCharacterManager = collision.gameObject.GetComponent<CharacterManager>();
        if (hitCharacterManager != null)
        {
            // check what type of spell this is
            switch (CheckType())
            {
                // if it's an attack, damage any chatacters we hit
                case "Attack":
                    hitCharacterManager.TakeDamage(spellEffectAmount, spellEffectType);
                    break;

                default:
                    Debug.Log("No Valid Spell Type Found");
                    break;
            }
        }
    }

    private string CheckType()
    {
        switch (spellType)
        {
            case "Attack":
                return "Attack";

            default:
                return "No Valid Spell Type Found";
        }
    }

    public override EnemyManager CheckForTarget(Vector2 origin)
    {
        return null;
    }
}
