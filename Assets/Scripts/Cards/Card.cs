using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Card : MonoBehaviour {

    public string id;
    public string title;
    public string description;
    public Level lvl;
    public Universe universe;
    public bool wasDrawn;
    public bool wasPlayed;
    public bool inHand;

}
