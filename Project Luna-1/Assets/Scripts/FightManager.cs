using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FightManager : MonoBehaviour
{
    //Placeholder for testing
    public FighterScript Player;
    private Fight currentFight;

    public Transform PositionsParent;

    private static FightManager p_instance;
    public FightManager Instance {
        get {
            if (p_instance == null) {
                p_instance = FindObjectOfType<FightManager>();
            }
            return p_instance;
        }

    }

    private void Start() {

        Player = SpawnPlayer();

        StartCoroutine(StartNewFight());

    }

    public FighterScript SpawnPlayer() {
        var ft = Instantiate(AssetManager.Instance.BaseFighterPrefab).GetComponent<FighterScript>();
        ft.SetGo(AssetManager.Instance.GetPlayerFighter());
        ft.isPlayer = true;
        ft.transform.position = PositionsParent.GetChild(0).transform.position;
        return ft;
    }

    public FighterScript SpawnNewEnemy() {
        var ft2 = Instantiate(AssetManager.Instance.BaseFighterPrefab).GetComponent<FighterScript>();
        ft2.SetGo(AssetManager.Instance.GetRandomFighter());
        ft2.transform.position = PositionsParent.GetChild(1).transform.position;
        return ft2;
    }

    private IEnumerator StartNewFight() {

        yield return new WaitForSeconds(2f);
        var ft2 = SpawnNewEnemy();
        currentFight = new Fight(Player, ft2);
        currentFight.StartFight();
        currentFight.PlayerSurviveEvent += FightEnd;
    }

    public void FightEnd(bool isPlayerAlive) {
        currentFight.PlayerSurviveEvent -= FightEnd;

        if (isPlayerAlive) {

           StartCoroutine(StartNewFight());

        }

    }

    


    //Just 2 fighters for now
    public class Fight {
        public Action<bool> PlayerSurviveEvent;
        private FighterScript P_1;
        private FighterScript P_2;

        public Fight(FighterScript player, FighterScript enemy) {
            P_1 = player;
            P_2 = enemy;

        }

        public void StartFight() {

            P_2.FighterDieEvent += PlayerWin;
            P_1.FighterDieEvent += PlayerLose;
            P_1.StartAttack();
            P_2.StartAttack();


        }

        private void PlayerWin() {
            P_2.FighterDieEvent -= PlayerWin;
            P_1.FighterDieEvent -= PlayerLose;

            P_1.StopAttack();
            PlayerSurviveEvent?.Invoke(true);
            Debug.Log("Player wins!");
        }

        private void PlayerLose() {
            P_2.StopAttack();
            P_2.FighterDieEvent -= PlayerWin;
            P_1.FighterDieEvent -= PlayerLose;

            Debug.Log("Player is dead!");
            PlayerSurviveEvent?.Invoke(false);

        }

        

    }



    
}
