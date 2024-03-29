﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : Card
{

    // Start is called before the first frame update
    void Start()
    {
        this.manaCost = 1;
    }

    public override void CardEffect(PlayerBattle player, EnemyBattle enemy)
    {
        enemy.health -= 2;
        if (enemy.health < 0)
        {
            enemy.health = 0;
        }
    }

    public override int ManaCost()
    {
        return this.manaCost;
    }
}
