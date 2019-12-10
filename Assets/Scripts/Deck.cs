using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cardList;

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
        int n = cardList.Count;
        Card card = cardList[Random.Range(0, n)];
        return Instantiate(card);
    }

}
