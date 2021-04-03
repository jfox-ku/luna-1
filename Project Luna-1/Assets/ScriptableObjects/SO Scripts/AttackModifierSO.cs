using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Attack Modifier", menuName = "ScriptableObjects/AttackModifier")]
public class AttackModifierSO : ScriptableObject
{
    public string modifierName;
    public float damageMultiplier;
    public float stunChanceIncreace;
    public float slowChanceIncrease;

}
