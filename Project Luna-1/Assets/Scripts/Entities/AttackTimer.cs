using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackTimer : MonoBehaviour
{
    public Action AttackEvent;
    public Action<float> attackPercentChangeEvent;
    public float attackCooldown;
    private float currentCooldown;
    public bool stunned;
    public bool slowed;

    public const float  CooldownInterval = 0.2f;

    public Action TimerDestroyedEvent;
    private void OnDestroy() {
        TimerDestroyedEvent?.Invoke();
    }


    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = attackCooldown;
        stunned = false;
        slowed = false;



    }


    public void StunForSec(float sec) {

        stunned = true;
        FunctionTimer.Create(() => stunned = false,sec);
    }

    public void SlowForSec(float sec) {

        slowed = true;
        FunctionTimer.Create(() => slowed = false, sec);
    }

    public void StartAttackLoop() {
        StopAllCoroutines();
        StartCoroutine(AttackLoop());
    }

    public void StopAttackLoop() {
        StopAllCoroutines();
        
    }


    private IEnumerator AttackLoop() {

        while (true) {
            yield return new WaitForSeconds(CooldownInterval);

            if (!stunned) {


                if (currentCooldown > 0) {
                    if (slowed) {
                        currentCooldown -= CooldownInterval / 2f;
                    } else {
                        currentCooldown -= CooldownInterval;
                    }

                    attackPercentChangeEvent?.Invoke(1f-(currentCooldown/attackCooldown));

                } else {
                    attackPercentChangeEvent?.Invoke(0f);
                    AttackEvent?.Invoke();
                    currentCooldown = attackCooldown;

                }

            }
        }

    }
}
