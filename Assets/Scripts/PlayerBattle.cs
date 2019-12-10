using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    public int health = 20;
    public int mana = 1;
    public Deck deck;
    public PlayerHand cardsInHand;
    

    public void ResetStats()
    {
        this.health = 20;
    }
}
