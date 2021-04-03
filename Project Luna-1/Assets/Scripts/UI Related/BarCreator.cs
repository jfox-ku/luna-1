using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCreator : MonoBehaviour
{
    public static List<GameObject> hbarsList;
    public GameObject hbarPrefab;

    public static List<GameObject> abarsList;
    public GameObject abarPrefab;

    public void CreateHealthBar(HealthScript hs) {
        if (hbarsList == null) {
            hbarsList = new List<GameObject>();
        }

        var bar =Instantiate(hbarPrefab,hs.transform.position+Vector3.up*1.4f,Quaternion.identity,this.transform);
        bar.GetComponent<HealthDisplayScript>().SetMyGuy(hs);

        hbarsList.Add(bar);

    }

    public void CreateAttackBar(AttackScript asc) {
        if (abarsList == null) {
            abarsList = new List<GameObject>();
        }

        var bar = Instantiate(abarPrefab, asc.transform.position + Vector3.up * 1.2f, Quaternion.identity, this.transform);
        bar.GetComponent<AttackBarDisplay>().SetMyGuy(asc.ATimer);

        abarsList.Add(bar);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
