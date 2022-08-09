using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START , PLAYERTURN, ENEMYTURN, VICTORY, DEFEAT }
public class BattleManager : MonoBehaviour
{
    //character prefabs
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    //character positions
    public Transform playerPosition;
    public Transform enemyPosition;

    //character stats
    private  CharacterStats playerStats;
    private  CharacterStats enemyStats;

    //battle states
    public BattleState state;

    private void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    //function to setup the battle
    private void SetupBattle()
    {
        GameObject player =  Instantiate(playerPrefab, playerPosition);
        playerStats = player.GetComponent<CharacterStats>();

        GameObject enemy = Instantiate(enemyPrefab, enemyPosition);
        enemyStats = enemy.GetComponent<CharacterStats>();

        state = BattleState.PLAYERTURN;
    }
}
