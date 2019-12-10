using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndTurnButton : MonoBehaviour, IPointerClickHandler
{
    private PlayerHand playerHand;

    // Start is called before the first frame update
    void Awake()
    {
        //Hide cards until they need to be displayed
        //SetActive(false);
        playerHand = this.transform.parent.GetComponent<PlayerHand>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        playerHand.endTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
