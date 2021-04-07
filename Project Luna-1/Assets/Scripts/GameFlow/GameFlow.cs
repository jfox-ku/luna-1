using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class GameFlow
{

    public Action FlowEndEvent;

    public virtual void Initialize() {

    }
    
    public virtual void EndFlow() {
        FlowEndEvent?.Invoke();
    }


}
