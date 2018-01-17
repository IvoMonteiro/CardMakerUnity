using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanelController : MonoBehaviour {

    public GameObject SidePanel;
    public GameObject CardPanel;
    public GameObject currentDeckPanel;
    public GameObject HeroCard;
    public GameObject VillainCard;
    public GameObject HordeCard;
    public GameObject SettingCard;
    public GameObject QuestCard;
    public GameObject SideQuestCard;
    public GameObject ItemCard;
    public GameObject ItemEquipCard;
    public GameObject ItemSpellCard;
    public GameObject ItemSummonCard;
    public GameObject SpellCard;
    public GameObject SummonCard;

    private int currentIndex = 0;
    public GameObject currentObj;
    public Card currentCard;
    private List<GameObject> instantiated;

    private List<GameObject> list;

    public void Start()
    {


        instantiated = new List<GameObject>(20);

        instantiated.Add(Instantiate(HeroCard, CardPanel.transform));
        instantiated.Add(Instantiate(VillainCard, CardPanel.transform));
        instantiated.Add(Instantiate(HordeCard, CardPanel.transform));
        instantiated.Add(Instantiate(SettingCard, CardPanel.transform));
        instantiated.Add(Instantiate(QuestCard, CardPanel.transform));
        instantiated.Add(Instantiate(SideQuestCard, CardPanel.transform));
        instantiated.Add(Instantiate(ItemCard, CardPanel.transform));
        instantiated.Add(Instantiate(SpellCard, CardPanel.transform));
        instantiated.Add(Instantiate(SummonCard, CardPanel.transform));

        list = new List<GameObject>(20);
        list.Add(HeroCard);
        list.Add(VillainCard);
        list.Add(HordeCard);
        list.Add(SettingCard);
        list.Add(QuestCard);
        list.Add(SideQuestCard);
        list.Add(ItemCard);
        list.Add(SpellCard);
        list.Add(SummonCard);
    }

    public void ShowCardByIndex(int index)
    {
        if (currentObj != null)
            currentObj.SetActive(false);

        currentIndex = index - 1;

        currentObj = instantiated[currentIndex];
        currentObj.SetActive(true);
        currentCard = currentObj.GetComponent<Card>();
        

    }

    public void SendToDeck()
    {
        Debug.Log(currentCard);
        if (currentCard != null)
        {
            Card i = Instantiate(currentCard, currentDeckPanel.transform);
            Debug.Log(i.GetType());
            currentDeckPanel.GetComponent<Deck>().listCards.Add(i);
            //SidePanel.GetComponent<DeckList>().currentDeck.listChar.Add(i);
        }
            
        
    }

    public void Export()
    {

    }
}
