using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FunctionTimer.Create(Attack,3f);
        FunctionTimer.Create(Attack, 4f);

    }

    private void Attack() {
        Debug.Log("Attack was called!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
