using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cardList;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            cardList[i] = Instantiate(cardList[i]);
            cardList[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        foreach (Card card in cardList)
        {
            Destroy(card.gameObject);
        }
        cardList = null;
    }

    public void AddCard(Card card)
    {
        cardList.Add(card);
    }

    public Card DrawCard()
    {
        int n = cardList.Count;
        Card card = cardList[Random.Range(0, n)];
        return Instantiate(card);
    }

}
