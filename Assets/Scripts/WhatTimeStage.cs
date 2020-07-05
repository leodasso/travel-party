using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arachnid;

public class WhatTimeStage : MonoBehaviour
{
    public Clock clock;
    
    public List<TimeCard> cards = new List<TimeCard>();
    TimeCard _chosenCard;
    
    void OnEnable()
    {
        Debug.Log("time stage enabled");
        _chosenCard = Math.RandomElementOfList(cards);
        
        Debug.Log("chosen card:" + _chosenCard.name, _chosenCard);

        clock.hour = _chosenCard.hour;
        clock.minute = _chosenCard.minute;
        clock.ApplyTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
