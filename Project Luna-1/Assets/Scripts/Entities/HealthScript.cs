using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthScript : MonoBehaviour
{

    public Action<float> healhPercentChangeEvent;
    public Action DieEvent;

    public float maxHealh;
    public float currentHealth;

    public Transform PopUpPosition;

    private void Start() {
        var BarCreator = FindObjectOfType<BarCreator>();
        BarCreator.CreateHealthBar(this);
    }


    public void SetMaxHealth(float ma) {
        maxHealh = ma;
        currentHealth = ma;
        
    }

    public void TakeDamage(float dmg) {
        currentHealth -= dmg;
        DmgPopUp.Create(PopUpPosition.position,(int)dmg);
        if (currentHealth <= 0) Die();
        else {
            healhPercentChangeEvent?.Invoke(currentHealth/maxHealh);
        }


    }

    private void Die() {
        
        healhPercentChangeEvent?.Invoke(0);
        DieEvent?.Invoke();
        Destroy(this.gameObject);

    }


}
