using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FighterScript : MonoBehaviour
{
    public bool isPlayer=false;
    public FighterSO FSO;

    public AttackScript AS;
    public HealthScript HS;
    public SpriteRenderer Sprt;

    public Action FighterDieEvent;

    public void SetGo(FighterSO so) {
        FSO = so;
        Initialize();
    }

    void Initialize()
    {

        if (FSO == null) {
            Debug.LogError("Fighter lacks SO");
            return;
        }

        AS = GetComponent<AttackScript>();
        HS = GetComponent<HealthScript>();
        Sprt = GetComponentInChildren<SpriteRenderer>();

        
        ReadFromSO();
        //FSO.ReadInto(this);
       

        HS.DieEvent += FighterDie;
    }

    private void ReadFromSO() {
        this.gameObject.name = FSO.FighterName;

        HS.SetMaxHealth(FSO.MaxHP);
        AS.SetAttackCooldown(FSO.baseAttackCooldown);
        AS.AttackDamage = FSO.baseDamage;

        if (Sprt != null) {
            Sprt.sprite = FSO.FighterSprite;
        }

        if (HS == null) {
            Debug.LogError(this.transform.name + " does not contain health script! Can't fight!");
            return;
        }
    }

    public void StartAttack() {
        AS.ATimer.StartAttackLoop();
    }


    public void StopAttack() {
        AS.ATimer.StopAttackLoop();
    }

    private void FighterDie() {
        FighterDieEvent?.Invoke();

    }

    public FighterState GetMyState() {
        return new FighterState(AS.ATimer.stunned,AS.ATimer.slowed);

    }
}
