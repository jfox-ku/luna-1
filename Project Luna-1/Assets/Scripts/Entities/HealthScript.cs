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

    private void Start() {
        var BarCreator = FindObjectOfType<BarCreator>();
        BarCreator.CreateHealthBar(this);
    }

    public void TakeDamage(float dmg) {
        Debug.Log("Taking "+dmg+ " damage!");
        currentHealth -= dmg;
        if (currentHealth <= 0) Die();
        else {
            healhPercentChangeEvent?.Invoke(currentHealth/maxHealh);
        }


    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            TakeDamage(2f);
        }
    }

    private void Die() {
        
        healhPercentChangeEvent?.Invoke(0);
        DieEvent?.Invoke();
        Destroy(this.gameObject);

    }


}
