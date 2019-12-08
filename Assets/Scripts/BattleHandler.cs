using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BattleHandler manages the control flow logic of a battle.
//BattleHandler is instantiated whenever a battle starts.
//The player and enemy objects are passed in at instantiation.
//When the battle is over the BattleHandler is destroyed
public class BattleHandler : MonoBehaviour
{
    public enum BattleState {PlayerTurn, EnemyTurn, PlayerWin, EnemyWin };

    public PlayerBattle player;
    public PlayerHand cardsInHand;
    public EnemyBattle enemy;
    public BattleState state;

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
    }

    // Update is called once per frame
    void Update()
    {
        //At start: disable overworld movement and position player/enemy for battle

        //Player turn:
        //1. display player hand, player health, enemy health
        //2. Stall until player takes their turn, using click event handling
        //3. Perform selected player action (call card's effect function, update health/status etc)
        //4. update state (remove card from hand, take new one from deck)

        //Enemy turn:
        //5. Perform basic enemy attack, updating player health/status

        //Between Turns:
        //6. Check condition for battle end state (i.e. if player or enemy are defeated)
        //7. Reset overworld state, player deck, etc
        //8. destroy/disable overworld enemy
        //9. destroy battle handler
    }
}
