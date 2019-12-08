using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> cardList;
    private const int capacity = 15;

    // Start is called before the first frame update
    void Start()
    {
        this.cardList = new List<Card>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        foreach (Card card in cardList)
        {
            Destroy(card);
        }
        cardList = null;
    }

    void AddCard(Card card)
    {
        cardList.Add(card);
    }

    Card DrawCard()
    {
        Card ret = null;
        if(cardList.Count > 0)
        {
            ret = cardList[0];
            cardList.RemoveAt(0);
        }
        return ret;
    }

    void Shuffle()
    {
        int n = cardList.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n+1);
            Card value = cardList[k];
            cardList[k] = cardList[n];
            cardList[n] = value;
        }
    }
}
