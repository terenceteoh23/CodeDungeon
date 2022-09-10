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
    private Player player;
    private CharacterInfo enemyUnit;

    //battle UI
    public Text battleDialog;

    //battleHUD
    public PlayerBattleHUD playerHUD;
    public EnemyBattleHUD enemyHUD;
    public Button AttackButton;
    public Button HealButton;

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

        battleDialog.text = "You have encountered a " + enemyUnit.Cname + ".";

        //setup the hud for both player and enemy
        playerHUD.SetHUD(player);
        enemyHUD.SetHUD(enemyUnit);

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

        battleDialog.text = "Your Turn.";
    }

    private IEnumerator EnemyTurn()
    {
        //change battle dialog
        battleDialog.text = "Enemy Turn.";

        //wait for 1 second
        yield return new WaitForSeconds(1f);

        //enemy attack player and take damage
        bool isDead = player.TakeDamage(enemyUnit.damage);

        //set player hud to reflect damage taken
        playerHUD.SetHp(player.currentHP);

        //change battle text to inform player 
        battleDialog.text = enemyUnit.Cname + " dealt " + enemyUnit.damage + " to you!";

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

        //attack enemy
        bool isDead = enemyUnit.TakeDamage(player.damage);

        //set enemy hud to reflect damage delt
        enemyHUD.SetHp(enemyUnit.currentHP);

        //change battle text to inform player
        battleDialog.text = "You dealt " + player.damage + " to " + enemyUnit.Cname + "!";

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

    private IEnumerator PlayerHeal()
    {
        //disable button
        AttackButton.interactable = false;
        HealButton.interactable = false;

        //call heal function
        player.Heal();

        //set player hud to reflect healing
        playerHUD.SetHp(player.currentHP);

        //change battle dialog relfect healing
        battleDialog.text = "You healed for 3 hp.";

        //wait for 1 second
        yield return new WaitForSeconds(1f);

        //change to enemy turn
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void AttackAction()
    {
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
            battleDialog.text = "VICTORY!!";
            Player player_1 = playerPrefab.GetComponent<Player>();
            player_1.SetStats(player);

            yield return new WaitForSeconds(3f);
            GameManager.instance.ChangeScene(player.lastScene);
        }
            
        else if (state == BattleState.DEFEAT)
            battleDialog.text = "You have been defeated......";
        
    }
}

