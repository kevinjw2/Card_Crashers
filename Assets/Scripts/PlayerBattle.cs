using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattle : MonoBehaviour
{
    public const int MAX_MANA = 5;
    public int health = 30;
    public int mana = 5;
    public int shield = 0;
    public Deck deck;
    public PlayerHand cardsInHand;
    public Text healthBar, manaBar, shieldBar;

    private void Update()
    {
        healthBar.text = "HEALTH:\t" + health;
        manaBar.text = "MANA:\t" + mana;
        shieldBar.text = "SHIELD:\t" + shield;

        if (shield < 0)
        {
            health += shield;
            shield = 0;
        }
        if (health < 0)
        {
            health = 0;
        }
    }

    public void ResetMana()
    {
        this.mana = MAX_MANA;
    }
}
