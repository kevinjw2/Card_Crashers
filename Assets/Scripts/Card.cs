using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public int manaCost;
    //TODO: add references to physical gameobject and image asset

    // Start is called before the first frame update
    void Start()
    {
        //Hide cards until they need to be displayed
        SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void CardEffect(PlayerBattle player, EnemyBattle enemy);

    public void SetActive(bool val)
    {
        this.gameObject.SetActive(val);
    }

}
