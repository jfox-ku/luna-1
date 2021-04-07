using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaitForFlow : GameFlow
{
    private Action cachedEvent;

    public void Initialize(Action Event) {
        base.Initialize();
        cachedEvent = Event;
        Event += EndFlow;



    }

    public override void Initialize() {
        base.Initialize();
        Debug.LogError("WaitForFlow needs an action to wait for!");
    }

    public override void EndFlow() {
        base.EndFlow();


    }



}
