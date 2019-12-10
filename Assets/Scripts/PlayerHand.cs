using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    public Card[] cardList;
    private Card clickedCard;
    public Text endTurnButton;
    public bool endTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        //cardList = new List<Card>();
        this.gameObject.SetActive(false);
        endTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: manage physical sorting/display of cards
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

    public void ResetCards()
    {
        foreach (Card card in cardList)
        {
            card.gameObject.SetActive(true);
        }
    }
}
