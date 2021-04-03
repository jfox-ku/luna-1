using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour
{
    private RandomManager p_instance;
    public RandomManager Instance {
        get {
            if(p_instance == null) {
                p_instance = FindObjectOfType<RandomManager>();
            }
            return p_instance;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        p_instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int Dice9Roll() {
        int rand = Random.Range(1,10);
        return rand;

    }
}
