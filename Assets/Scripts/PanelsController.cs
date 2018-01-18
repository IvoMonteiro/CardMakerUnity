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

            GameObject i = null;
            GameObject dp = DecksPanel.GetComponent<DeckPanelsController>().currentDeckPanel;
            string type = currentCard.GetType().ToString();
            
            Debug.Log(type);
            switch(type)
            {
                case "Hero":
                    i = Instantiate(currentObj, transform.parent.Find("DecksPanel/CharactersPane").transform);
                    dp.GetComponent<Deck>().deckData.listCharacters.Add(i.GetComponent<Character>().data);
                    break;
                case "Villain":
                    i = Instantiate(currentObj, transform.parent.Find("DecksPanel/CharactersPane").transform);
                    dp.GetComponent<Deck>().deckData.listCharacters.Add(i.GetComponent<Villain>().data);
                    break;
                case "Generic":
                    i = Instantiate(currentObj, transform.parent.Find("DecksPanel/CharactersPane").transform);
                    dp.GetComponent<Deck>().deckData.listCharacters.Add(i.GetComponent<Generic>().data);
                    break;
                case "Quest":
                    i = Instantiate(currentObj, transform.parent.Find("DecksPanel/QuestsPane").transform);
                    dp.GetComponent<Deck>().deckData.listQuests.Add(i.GetComponent<Quest>().data);
                    break;
                case "SideQuest":
                    i = Instantiate(currentObj, transform.parent.Find("DecksPanel/QuestsPane").transform);
                    dp.GetComponent<Deck>().deckData.listQuests.Add(i.GetComponent<SideQuest>().data);
                    break;
                case "Setting":
                    i = Instantiate(currentObj, transform.parent.Find("DecksPanel/SettingsPane").transform);
                    dp.GetComponent<Deck>().deckData.listSettings.Add(i.GetComponent<Setting>().data);
                    break;
                case "Item":
                    i = Instantiate(currentObj, dp.transform);
                    dp.GetComponent<Deck>().deckData.listCards.Add(i.GetComponent<Item>().data);
                    break;
                case "Spell":
                    i = Instantiate(currentObj, dp.transform);
                    dp.GetComponent<Deck>().deckData.listCards.Add(i.GetComponent<Spell>().data);
                    break;
                case "Summon":
                    i = Instantiate(currentObj, dp.transform);
                    dp.GetComponent<Deck>().deckData.listCards.Add(i.GetComponent<Summon>().data);
                    break;
                default:
                    i = Instantiate(currentObj, dp.transform);
                    dp.GetComponent<Deck>().deckData.listCards.Add(i.GetComponent<Card>().cardData);
                    break;
            }
            i.GetComponent<Card>().cardData.type = type;
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
