using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DeckData {

    public string id;
    public string title;
    public int number_spells;
    public int number_summons;
    public int number_items;
    public int number_sidequests;
    public int[] ratios;

    public List<CardData> listCards;
    public List<SettingData> listSettings;
    public List<QuestData> listQuests;
    public List<CharacterData> listCharacters;
}
