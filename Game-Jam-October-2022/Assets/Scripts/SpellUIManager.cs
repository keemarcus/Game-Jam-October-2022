using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellUIManager : MonoBehaviour
{
    public Slider energySlider;
    public SpellImageManager[] spellImageManagers;
    
    void Awake()
    {
        energySlider = this.gameObject.GetComponentInChildren<Slider>();
        spellImageManagers = this.gameObject.GetComponentsInChildren<SpellImageManager>();
    }

    public void SetEnergyAmount(float newAmount)
    {
        // make sure we're setting the amount somewhere between 0 and 100
        newAmount = Mathf.Clamp(newAmount, 0, 100);

        // set the value of the slider
        energySlider.value = newAmount;
    }

    public void SetActiveSpell(int index)
    {
        foreach(SpellImageManager manager in spellImageManagers)
        {
            if(manager.spellIndex == index)
            {
                manager.SetActive(true);
            }
            else
            {
                manager.SetActive(false);
            }
        }
    }

    public void SetSpellImage(int index, Sprite newImage)
    {
        foreach (SpellImageManager manager in spellImageManagers)
        {
            if (manager.spellIndex == index)
            {
                manager.SetImage(newImage);
            }
        }
    }
}
