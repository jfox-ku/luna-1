using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBarDisplay : MonoBehaviour
{
    public Image YellowBar;
    public AttackTimer Attacker;

    public void SetMyGuy(AttackTimer timer) {
        Attacker = timer;
        Attacker.attackPercentChangeEvent += ChangePercent;
        Attacker.TimerDestroyedEvent += Die;
    }
    

   

    private void ChangePercent(float f) {
        
        YellowBar.fillAmount = f;
    }

    private void Die() {
        Destroy(this.gameObject);
    }

    private void OnDestroy() {
        if (Attacker != null) {
            Attacker.attackPercentChangeEvent -= ChangePercent;
        }
    }


}
