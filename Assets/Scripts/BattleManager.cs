using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private CharacterInfo playerUnit;
    private CharacterInfo enemyUnit;

    //battle UI
    public Text battleDialog;

    //battleHUD
    public PlayerBattleHUD playerHUD;
    public EnemyBattleHUD enemyHUD;

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
        playerUnit = player.GetComponent<CharacterInfo>();

        GameObject enemy = Instantiate(enemyPrefab, enemyPosition);
        enemyUnit = enemy.GetComponent<CharacterInfo>();

        battleDialog.text = "You have encountered a " + enemyUnit.Cname + ".";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        state = BattleState.PLAYERTURN;
    }
}
