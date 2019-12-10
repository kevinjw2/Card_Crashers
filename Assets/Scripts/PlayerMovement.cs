using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Tilemap ground, obstacles, enemy;
    Vector3 pos;
    public float speed;
    private BattleHandler battle;
    private TileBase enemyTile;
    private Vector3 enemyPos;

    void Start()
    {
        pos = transform.position; // Take the current position
        battle = null;
        enemyTile = null;
    }

    void Update()
    {
        //Disable movement when in battle
        if(battle != null)
        {
            if (battle.state == BattleHandler.BattleState.PlayerWin)
            {
                //End battle
                Destroy(battle);
                battle = null;
                //Disable enemy tile
                enemy.SetTile(enemy.WorldToCell(enemyPos), null);
                enemyTile = null;
            }
            else if (battle.state == BattleHandler.BattleState.EnemyWin)
            {
                //Game over
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }

                return;
        }

        //Only move if we're not currently moving between tiles
        if (transform.position == pos)
        {
            InputToMovement();
        }
        else
        {
            Move();
        }
    }

    //Perform smooth movement between tiles
    void Move()
    {
        //Move to current position
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }

    //Tile movement calculation
    void InputToMovement()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);

        //Check player inputs
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir = Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir = Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir = Vector3.down;
        }

        Vector3 newPos = pos + moveDir;

        //Check tilemap for terrain condition at new position
        TileBase groundTile = ground.GetTile(ground.WorldToCell(newPos));
        TileBase obstacleTile = obstacles.GetTile(obstacles.WorldToCell(newPos));
        enemyTile = enemy.GetTile(enemy.WorldToCell(newPos));
        enemyPos = newPos;

        if (enemyTile != null)
        {
            //Enemy encounter
            PlayerBattle player = this.gameObject.GetComponent<PlayerBattle>();
            EnemyBattle enemy = new EnemyBattle();
            battle = this.gameObject.AddComponent<BattleHandler>();
            battle.player = player;
            battle.enemy = enemy;
            battle.enemy.pos = enemyPos;
        }
        else if (groundTile != null && obstacleTile == null)
        {
            pos = newPos;
        }
        
    }

}
