using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattle
{
    public int health = 15;
    public int attack = 3;
    public Vector3 pos;

    public void Attack(PlayerBattle player)
    {
        player.shield -= attack;
    }

}
