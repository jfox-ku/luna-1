using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour
{
    public AttackScript AS;
    public HealthScript HS;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AttackScript>();
        HS = GetComponent<HealthScript>();

        if (HS == null) {
            Debug.LogError(this.transform.name+" does not contaain health script! Can't fight!");
            return;
        }

        HS.DieEvent += FighterDie;
    }

    public void StartAttack() {
        AS.ATimer.StartAttackLoop();
    }


    private void FighterDie() {

    }

    public FighterState GetMyState() {
        return new FighterState(AS.ATimer.stunned,AS.ATimer.slowed);

    }
}
