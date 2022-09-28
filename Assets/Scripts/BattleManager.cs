using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    private Player player; 
    private CharacterInfo enemyUnit;

    //battle hud
    public BattleHUDManager battleHUD;
    public Button AttackButton;
    public Button HealButton;

    //battle puzzle
    public PuzzleManagerMCQ puzzleManagerMCQ;

    //battle states
    public BattleState state;


    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    //function to setup the battle
    private IEnumerator SetupBattle()
    {    
        //create the game objects for player and the enemies
        GameObject playerGO = Instantiate(playerPrefab, playerPosition);
        player = playerGO.GetComponent<Player>();

        GameObject enemy = Instantiate(enemyPrefab, enemyPosition);
        enemyUnit = enemy.GetComponent<CharacterInfo>();

        //disable certain scripts
        playerGO.GetComponent<PlayerMovement>().enabled = false;

        battleHUD.UpdateBattleDialog("You have encountered a " + enemyUnit.Cname + ".");

        //setup the hud for both player and enemy
        battleHUD.BattleSetup(player, enemyUnit);

        //wait for 2 seconds
        yield return new WaitForSeconds(2f);

        //change state to player turn
        state = BattleState.PLAYERTURN;
        PlayerTurn();

       
    }
    private void PlayerTurn()
    {
        //enable buttons
        AttackButton.interactable = true;
        HealButton.interactable = true;

        //change battle dialog
        battleHUD.UpdateBattleDialog("Your Turn.");
    }

    private IEnumerator EnemyTurn()
    {
        //change battle dialog
        battleHUD.UpdateBattleDialog("Enemy Turn.");

        //wait for 1 second
        yield return new WaitForSeconds(1f);

        //enemy attack player and take damage
        bool isDead = player.TakeDamage(enemyUnit.damage);

        //set player hud to reflect damage taken
        battleHUD.playerHUD.SetHp(player.currentHP);

        //change battle text to inform player 
        battleHUD.UpdateBattleDialog(enemyUnit.Cname + " dealt " + enemyUnit.damage + " to you!");

        //wait for 1 second
        yield return new WaitForSeconds(2f);

        
        //check if player is dead
        if (isDead)
        {
            //if player dead then defeated
            state = BattleState.DEFEAT;
            EndBattle();
        }
        else
        {   
            //else player turn
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    private IEnumerator PlayerAttack()
    {
        //disable button
        AttackButton.interactable = false;
        HealButton.interactable = false;

        //wait for 2 seconds
        yield return new WaitForSeconds(2f);
        battleHUD.HideSecondBattleHUD();

        //attack enemy
        int damage = player.Attack();

        //cheeck if the player answered the question correctly
        if (puzzleManagerMCQ.GetCorrect())
        {
            double db_damage = Convert.ToDouble(damage);
            db_damage = db_damage * 1.25;
            damage = Convert.ToInt32(db_damage);

        }

        bool isDead = enemyUnit.TakeDamage(damage);

        //set enemy hud to reflect damage delt
        battleHUD.enemyHUD.SetHp(enemyUnit.currentHP);

        //change battle text to inform player
        battleHUD.UpdateBattleDialog("You dealt " + damage + " to " + enemyUnit.Cname + "!");

        //wait for 2 seconds
        yield return new WaitForSeconds(2f);

        //check if enemy is dead
        if (isDead)
        {
            //if enemy dead then victory
            state = BattleState.VICTORY;
            StartCoroutine(EndBattle()) ;
        }
        else
        {
            //else enemy turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    public void OpenPuzzleAttack()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        else
        {
            battleHUD.ShowSecondBattleHUD();
        }

    }

    private IEnumerator PlayerHeal()
    {
        //disable button
        AttackButton.interactable = false;
        HealButton.interactable = false;

        //call heal function
        player.Heal();

        //set player hud to reflect healing
        battleHUD.playerHUD.SetHp(player.currentHP);

        //change battle dialog relfect healing
        battleHUD.UpdateBattleDialog("You healed for 3 hp.");

        //wait for 1 second
        yield return new WaitForSeconds(1f);

        //change to enemy turn
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void AttackAction()
    {
        //execute attack 
        if(state != BattleState.PLAYERTURN)
            return;
        else
        {
            StartCoroutine(PlayerAttack());
        }
        
    }

    public void HealAction()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        else
        {
            StartCoroutine(PlayerHeal());
        }

    }

    private IEnumerator EndBattle()
    {
        if (state == BattleState.VICTORY)
        {
            battleHUD.UpdateBattleDialog("VICTORY!!");
            Player player_1 = playerPrefab.GetComponent<Player>();
            player_1.SetStats(player);

            yield return new WaitForSeconds(3f);
            GameManager.instance.ChangeScene(player.lastScene);
        }
            
        else if (state == BattleState.DEFEAT)
        {
            battleHUD.UpdateBattleDialog("You have been defeated......");
        }
            
    }
}

