using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle
{
    public int health = 8;
    public int attack = 2;

    public void Attack(PlayerBattle player)
    {
        player.health -= attack;
        if (player.health < 0)
        {
            player.health = 0;
        }
    }

}
