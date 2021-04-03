using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Variant", menuName = "ScriptableObjects/AttackVariant")]
public class AttackSO : ScriptableObject
{
    public string attackName;
    public float attackBaseDamage;
    public float stunChance;
    public float slowChance;
    public Sprite attackSprite;



}
