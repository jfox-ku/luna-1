using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackScript : MonoBehaviour
{
    private HealthScript Target;
    public AttackTimer ATimer;
    public float AttackDamage = 5f;



    // Start is called before the first frame update
    void Start()
    {
        ATimer = GetComponent<AttackTimer>();
        ATimer.AttackEvent += Attack;
        FindTarget();

        var BarCreator = FindObjectOfType<BarCreator>();
        BarCreator.CreateAttackBar(this);

    }

    public void Attack() {
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
            yield return new WaitForSeconds(1f);
            var hList = FindObjectsOfType<HealthScript>();
            foreach (HealthScript item in hList) {
                if (item.transform != this.transform) {
                    Target = item;
                    
                }
            }
        }


    }

    


}
