using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackScript : MonoBehaviour
{
    //Placeholder target to attack.
    private HealthScript Target;
    public AttackTimer ATimer;
    public float AttackDamage = 5f;

    private bool AmIPlayer;

    public void SetAttackCooldown(float f) {
        ATimer.attackCooldown = f;
    }


    public void ActivateAttackFromIndex(int index,Draggable card) {
        Debug.Log("Activating card: "+card.attackData.attackName);
        AttackDamage = card.attackData.attackBaseDamage;
        AttackEffect();

    }

    // Start is called before the first frame update
    void Start()
    {
        AmIPlayer = this.GetComponent<FighterScript>().isPlayer;

        ATimer = GetComponent<AttackTimer>();
        ATimer.AttackEvent += TimerAttack;

        if (AmIPlayer) {
            for (int i = 0; i < FramePiece.FramesList.Count; i++) {
                FramePiece.FramesList[i].CardActivateEvent += ActivateAttackFromIndex;
            }
        }

        var BarCreator = FindObjectOfType<BarCreator>();
        BarCreator.CreateAttackBar(this);

    }

    public void TimerAttack() {

        FindTarget();
        
        if (AmIPlayer) {
            int roll = RandomManager.MappedRoll();
            Debug.Log("Rolled: "+roll);
            FramePiece.ActivateIndex(roll);

        } else {

            AttackEffect();
            
        }

    }

    public void AttackEffect() {
        if (Target == null) {
            FindTarget();
            if (Target == null) {
                Debug.Log("Can't find nothin' to attack!");
                return;
            }

        } else {
            Target.TakeDamage(AttackDamage);

        }
    }



    

    private void FindTarget() {
        var hList = FindObjectsOfType<HealthScript>();
        foreach (HealthScript item in hList) {
            if (item.transform != this.transform) {
                Target = item;
                return;
            }
        }

    }

    //Not used yet
    private IEnumerator FindTargetCo() {
        while (Target == null) {
            yield return new WaitForSeconds(0.5f);
            var hList = FindObjectsOfType<HealthScript>();
            foreach (HealthScript item in hList) {
                if (item.transform != this.transform) {
                    Target = item;
                    
                }
            }
        }


    }

    


}
