using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public CardData cardData;
    
    public void SetDescription(string str)
    {
        cardData.description = str;
    }
}
