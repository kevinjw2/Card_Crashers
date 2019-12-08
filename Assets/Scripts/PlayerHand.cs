using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    private List<Card> cardList;
    private const int capacity = 4;
    //TODO: physical instantiation of cards in hand, clickable handler

    // Start is called before the first frame update
    void Start()
    {
        cardList = new List<Card>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: manage physical sorting/display of cards
        //TODO: detect click on a card
    }

    public void AddCard(Card card)
    {
        cardList.Add(card);
    }
}
