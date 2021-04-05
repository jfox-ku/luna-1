using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public GameObject BaseFighterPrefab; 
    public List<FighterSO> FightersList;
    public List<AttackSO> AttacksList;

    private static AssetManager p_instance;
    public static AssetManager Instance {
        get {
            if (p_instance == null) {
                p_instance = FindObjectOfType<AssetManager>();
            }
            return p_instance;
        }

    }



    public FighterSO GetRandomFighter() {
        return FightersList[Random.Range(1,FightersList.Count)];

    }


    //FIST FIGHTER IS THE PLAYER FOR NOW
    public FighterSO GetPlayerFighter() {
        return FightersList[0];

    }

    void Awake()
    {
        
    }

 
}
