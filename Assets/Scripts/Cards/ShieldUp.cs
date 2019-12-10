using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : Card
{

    // Start is called before the first frame update
    void Start()
    {
        this.manaCost = 0;
    }

    public override void CardEffect(PlayerBattle player, EnemyBattle enemy)
    {
        player.shield += 4;
    }

    public override int ManaCost()
    {
        return this.manaCost;
    }
}
