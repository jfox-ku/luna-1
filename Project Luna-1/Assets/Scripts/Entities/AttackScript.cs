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


    public void SetAttackCooldown(float f) {
        ATimer.attackCooldown = f;
    }



    // Start is called before the first frame update
    void Start()
    {
        ATimer = GetComponent<AttackTimer>();
        ATimer.AttackEvent += Attack;

        var BarCreator = FindObjectOfType<BarCreator>();
        BarCreator.CreateAttackBar(this);

    }

    public void Attack() {

        FindTarget();
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
