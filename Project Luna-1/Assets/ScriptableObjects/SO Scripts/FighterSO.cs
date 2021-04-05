using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fighter Variant", menuName = "ScriptableObjects/Fighter Variant")]
public class FighterSO : ScriptableObject
{
    public string FighterName;
    public float MaxHP;
    public float baseDamage;
    public float baseAttackCooldown;
    public Sprite FighterSprite;


    public void ReadInto(FighterScript ne) {

        ne.gameObject.name = FighterName;
        ne.HS.SetMaxHealth(MaxHP);
        ne.AS.SetAttackCooldown(baseAttackCooldown);
        ne.AS.AttackDamage = baseDamage;

        if (ne.Sprt != null) {
            ne.Sprt.sprite = FighterSprite;
        }

        if (ne.HS == null) {
            Debug.LogError(ne.transform.name + " does not contain health script! Can't fight!");
            return;
        }



    }
    

}
