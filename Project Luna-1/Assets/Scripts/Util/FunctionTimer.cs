using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FunctionTimer
{
    private static List<FunctionTimer> activeTimerList;
    private static GameObject initGameObject;

    private static void InitCheck() {
        if (initGameObject == null) {
            initGameObject = new GameObject("FunctionTimer_Initializer");
            activeTimerList = new List<FunctionTimer>();

        }
    }

    private static void RemoveTimer(FunctionTimer toBeRemoved) {
        InitCheck();
        activeTimerList.Remove(toBeRemoved);

    }


    
    public static FunctionTimer Create(Action action,float timer) {
        InitCheck();
        var gameObject = new GameObject("FunctionTimer",typeof(MonoHook));
        gameObject.transform.SetParent(initGameObject.transform);
        FunctionTimer funcTimer = new FunctionTimer(action,timer,gameObject);
        gameObject.GetComponent<MonoHook>().onUpdate += funcTimer.UpdateTimer;

        activeTimerList.Add(funcTimer);

        return funcTimer;
    }

    public static void StopTimer(string timerName) {
        for (int i = 0; i < activeTimerList.Count; i++) {
            if(activeTimerList[i].timerName == timerName) {
                activeTimerList[i].DestroySelf();
                i--;

            }

        }

    }


    private class MonoHook : MonoBehaviour {
        public Action onUpdate;
        public void Update() {
            onUpdate?.Invoke();
        }
    }

    public void UpdateTimer() {
        if (!isDestroyed) {
            timer -= Time.deltaTime;
            if(timer < 0) {
                action();
                DestroySelf();
            }
        }

    }

    private void DestroySelf() {
        isDestroyed = true;
        UnityEngine.Object.Destroy(TimerHolder);
        RemoveTimer(this);
        
    }

    private Action action;
    private float timer;
    private bool isDestroyed;
    private GameObject TimerHolder;
    private string timerName;


    private FunctionTimer(Action act,float timer,GameObject obj,string timerName = null) {
        this.action = act;
        this.timer = timer;
        isDestroyed = false;
        TimerHolder = obj;
        this.timerName = timerName;


    }
}
