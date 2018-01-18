using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class PanelsController : MonoBehaviour {

    public GameObject SidePanel;
    public GameObject CardPanel;
    public GameObject DecksPanel;
    public GameObject HeroCard;
    public GameObject VillainCard;
    public GameObject HordeCard;
    public GameObject SettingCard;
    public GameObject QuestCard;
    public GameObject SideQuestCard;
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

    public GameData gameData;
    private string gameDataProjectFilePath = "/StreamingAssets/data.json";

    public void Start()
    {


        instantiated = new List<GameObject>(20);

        instantiated.Add(Instantiate(HeroCard, CardPanel.transform));
        instantiated.Add(Instantiate(VillainCard, CardPanel.transform));
        instantiated.Add(Instantiate(HordeCard, CardPanel.transform));
        instantiated.Add(Instantiate(SettingCard, CardPanel.transform));
        instantiated.Add(Instantiate(QuestCard, CardPanel.transform));
        instantiated.Add(Instantiate(SideQuestCard, CardPanel.transform));
        instantiated.Add(Instantiate(ItemEquipCard, CardPanel.transform));
        instantiated.Add(Instantiate(SpellCard, CardPanel.transform));
        instantiated.Add(Instantiate(ItemSpellCard, CardPanel.transform));
        instantiated.Add(Instantiate(SummonCard, CardPanel.transform));
        instantiated.Add(Instantiate(ItemSummonCard, CardPanel.transform));
        list = new List<GameObject>(20);
        list.Add(HeroCard);
        list.Add(VillainCard);
        list.Add(HordeCard);
        list.Add(SettingCard);
        list.Add(QuestCard);
        list.Add(SideQuestCard);
        list.Add(ItemEquipCard);
        list.Add(SpellCard);
        list.Add(ItemSpellCard);
        list.Add(SummonCard);
        list.Add(ItemSummonCard);
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
        if (currentCard != null)
        {
            Card i = null;
            GameObject dp = DecksPanel.GetComponent<DeckPanelsController>().currentDeckPanel;
            string type = currentCard.GetType().ToString();
            if(type == "Hero" || type == "Villain" || type == "Generic")
                i = Instantiate(currentCard, transform.parent.Find("DecksPanel/CharactersPane").transform);
            else if (type == "Quest" || type == "SideQuest")
                i = Instantiate(currentCard, transform.parent.Find("DecksPanel/QuestsPane").transform);
            else if (type == "Setting")
                i = Instantiate(currentCard, transform.parent.Find("DecksPanel/SettingsPane").transform);
            else
            {
                i = Instantiate(currentCard, dp.transform);
            }
            i.GetComponent<Card>().cardData.type = type;
            dp.GetComponent<Deck>().deckData.listCards.Add(i.GetComponent<Card>().cardData);
            //DecksPanel.GetComponent<DeckPanelsController>().GetComponent<DeckList>().decks.Up(dp.GetComponent<Deck>().deckData);
        }
            
        
    }

    public void Export()
    {
        GetComponent<DataController>().decks = DecksPanel.GetComponent<DeckPanelsController>().GetComponent<DeckList>().decks;
        gameData = new GameData();
        gameData.decks = GetComponent<DataController>().decks;
        string dataAsJson = JsonUtility.ToJson(gameData);

        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }

    public void Load()
    {
        string filePath = Application.dataPath + gameDataProjectFilePath;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(dataAsJson);
        }
        else
        {
            gameData = new GameData();
        }
    }
}
