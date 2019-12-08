using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Card[] cardList;
    private Card clickedCard;
    //private const int capacity;
    //TODO: physical instantiation of cards in hand, clickable handler

    // Start is called before the first frame update
    void Start()
    {
        //cardList = new List<Card>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: manage physical sorting/display of cards
        //TODO: detect click on a card
    }

    public void AddCard(Card card)
    {
        //cardList.Add(card);
    }

    public bool cardHasBeenClicked()
    {
        return clickedCard != null;
    }

    public Card getClicked()
    {
        Card ret = clickedCard;
        clickedCard = null;
        return ret;
    }

    public void setClicked(Card card)
    {
        this.clickedCard = card;
        Debug.Log("Clicked card has been set to " + card.transform.name);
    }
}
