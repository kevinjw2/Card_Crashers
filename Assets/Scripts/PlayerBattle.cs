using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    public int health;
    public Deck deck;
    //TODO: add health display

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        deck = new Deck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
