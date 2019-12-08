using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    public int health = 20;
    public Deck deck;
    public PlayerHand cardsInHand;
    //TODO: implement mana system

    public void ResetStats()
    {
        this.health = 20;
    }
}
