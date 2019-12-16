using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public List<Tilemap> ground, obstacles;
    public Tilemap enemy;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        bool inBattle = Battle();
        //Disable movement when in battle
        if (inBattle)
        {
            return;
        }

        Move();
    }

    //Perform smooth movement between tiles
    private void Move()
    {
        //Only move if we're not currently moving between tiles
        if (transform.position == pos)
        {
            InputToMovement();
        }
        else
        {
            //Move to current position
            transform.position = Vector3.MoveTowards(transform.position, pos, speed);
        }
    }

    //Tile movement calculation
    private void InputToMovement()
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

        //Check tilemaps for terrain condition at new position
        CheckObstacle(newPos);
        
    }

    private void CheckObstacle(Vector3 newPos)
    {
        //Check for enemies
        enemyTile = enemy.GetTile(enemy.WorldToCell(newPos));
        enemyPos = newPos;
        if (enemyTile != null)
        {
            //Enemy encounter, create a Battle instance
            PlayerBattle player = this.gameObject.GetComponent<PlayerBattle>();
            EnemyBattle enemy = new EnemyBattle();
            battle = this.gameObject.AddComponent<BattleHandler>();
            battle.player = player;
            battle.enemy = enemy;
            battle.enemy.pos = enemyPos;

            return;
        }

        //Check for obstacles
        foreach (Tilemap map in obstacles)
        {
            TileBase obstacleTile = map.GetTile(map.WorldToCell(newPos));
            if (obstacleTile != null)
            {
                // There is an obstacle in the way
                return;
            }
        }

        //Check for walkable ground
        foreach (Tilemap map in ground)
        {
            TileBase groundTile = map.GetTile(map.WorldToCell(newPos));
            if (groundTile != null)
            {
                //We can finally move
                pos = newPos;
            }
        }
    }

    private bool Battle()
    {
        if (battle != null)
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
                Quit();
            }

            return true;
        }

        return false;
    }

    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
