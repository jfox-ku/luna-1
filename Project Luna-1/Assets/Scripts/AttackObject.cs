using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject 
{
    private AttackSO baseAttackData;
    private AttackModifierSO baseModifier;

    public AttackObject(AttackSO aso, AttackModifierSO amso) {
        baseAttackData = aso;
        baseModifier = amso;
    }




}
