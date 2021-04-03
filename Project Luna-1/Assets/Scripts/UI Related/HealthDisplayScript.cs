using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayScript : MonoBehaviour
{

    public HealthScript myGuy;
    public Image RedBar;

   
    public void SetMyGuy(HealthScript guy)
    {
        myGuy = guy;
        myGuy.healhPercentChangeEvent += ChangePercent;
    }

    private void ChangePercent(float f) {
        
        RedBar.fillAmount = f;
        if (f <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy() {

        if(myGuy!=null)
        myGuy.healhPercentChangeEvent -= ChangePercent;
    }


    
}
