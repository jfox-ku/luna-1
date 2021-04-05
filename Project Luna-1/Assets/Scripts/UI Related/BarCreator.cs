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

        var bar =Instantiate(hbarPrefab,
            new Vector3(hs.transform.position.x,hs.GetComponentInChildren<SpriteRenderer>().bounds.extents.y+0.6f,hs.transform.position.z)
            ,Quaternion.identity,
            this.transform);

        bar.GetComponent<HealthDisplayScript>().SetMyGuy(hs);

        hbarsList.Add(bar);

    }

    public void CreateAttackBar(AttackScript asc) {
        if (abarsList == null) {
            abarsList = new List<GameObject>();
        }

        var bar = Instantiate(abarPrefab, 
            new Vector3(asc.transform.position.x, asc.GetComponentInChildren<SpriteRenderer>().bounds.extents.y + 0.3f,
            asc.transform.position.z), Quaternion.identity, this.transform);

        bar.GetComponent<AttackBarDisplay>().SetMyGuy(asc.ATimer);

        abarsList.Add(bar);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
