using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterState 
{
    public bool isStunned;
    public bool isSlowed;

    public FighterState(bool stunned, bool slowed) {
        isSlowed = slowed;
        isStunned = stunned;
    }


}
