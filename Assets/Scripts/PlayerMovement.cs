using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Tilemap ground, obstacles;
    Vector3 pos;
    public float speed;

    void Start()
    {
        pos = transform.position; // Take the current position
    }

    void Update()
    {
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

        if (groundTile != null && obstacleTile == null)
        {
            pos = newPos;
        }

        
    }

}
