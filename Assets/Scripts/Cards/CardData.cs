using System.Collections;
using UnityEngine;
[System.Serializable]
public class CardData {

    public string id;
    public string type;
    public string title;
    public string description;
    public Level lvl;
    public Universe universe;
    public bool wasDrawn;
    public bool wasPlayed;
    public bool inHand;
}
