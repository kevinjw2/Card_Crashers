using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Card : MonoBehaviour, IPointerClickHandler
{
    public int manaCost;
    private PlayerHand playerHand;

    // Start is called before the first frame update
    void Awake()
    {
        //Hide cards until they need to be displayed
        //SetActive(false);
        playerHand = this.transform.parent.GetComponent<PlayerHand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void CardEffect(PlayerBattle player, EnemyBattle enemy);

    public void OnPointerClick(PointerEventData eventData)
    {
        if (playerHand == null)
        {
            Debug.Log("Missing reference to playerHand");
        }
        else
        {
            Debug.Log("Card " + this.transform.name + " has received a click event.");
            playerHand.setClicked(this);
        }
    }

    public abstract int ManaCost();

    //public void SetActive(bool val)
    //{
    //    this.gameObject.SetActive(val);
    //}

}
