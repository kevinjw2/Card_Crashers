using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//BattleHandler manages the control flow logic of a battle.
//BattleHandler is instantiated whenever a battle starts.
//The player and enemy objects are passed in at instantiation.
//When the battle is over the BattleHandler is destroyed
public class BattleHandler : MonoBehaviour
{
    public enum BattleState {PlayerTurn, EnemyTurn, PlayerWin, EnemyWin};

    public PlayerBattle player;
    public PlayerHand cardsInHand;
    public EnemyBattle enemy;
    public BattleState state;
    //public Text enemyHealth;

    public BattleHandler(PlayerBattle player, EnemyBattle enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        state = BattleState.PlayerTurn;
        cardsInHand = player.cardsInHand;
        cardsInHand.gameObject.SetActive(true);

        //TODO display player health, enemy health
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current BattleState is " + state);
        Debug.Log("Player health is " + player.health);
        Debug.Log("Enemy health is " + enemy.health);
        //TODO: draw card, update hand, discard used card

        CheckWinState();
        if (state == BattleState.PlayerWin || state == BattleState.EnemyWin)
        {
            //TODO: Battle is over
            //This is currently handled in player movement script
        }

        if (state == BattleState.PlayerTurn)
        {
            //Player turn:
            if (!cardsInHand.endTurn)
            {
                Card clicked = cardsInHand.getClicked();
                if (clicked != null && clicked.ManaCost() <= player.mana)
                {
                    player.mana -= clicked.ManaCost();
                    clicked.CardEffect(player, enemy);
                }
                else
                {
                    //Not enough mana
                }

                
            }
            else
            {
                state = BattleState.EnemyTurn;
            }

            return;
        }
        else if (state == BattleState.EnemyTurn)
        {
            //Enemy turn:
            enemy.Attack(player);
            state = BattleState.PlayerTurn;
        }

        cardsInHand.endTurn = false;
        player.ResetMana();

    }

    private void OnDestroy()
    {
        //Reset world state before battle closes
        cardsInHand.gameObject.SetActive(false);
        //Destroy(enemyHealth);
    }

    //Checks conditions and sets the appropriate game state
    private void CheckWinState()
    {
        if (player.health <= 0)
        {
            state = BattleState.EnemyWin;
        }
        else if (enemy.health <= 0)
        {
            state = BattleState.PlayerWin;
        }
    }
}
