using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck : MonoBehaviour {
    public string id;
    public string title;
    public int number_spells;
    public int number_summons;
    public int number_items;
    public int number_sidequests;
    public int[] ratios;

    public List<Card> listCards;

    public List<Character> listChar;

    public List<Quest> listQuest;
    
   
}
