using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeckPanelsController : MonoBehaviour {

    public GameObject DeckPanel;
    private List<GameObject> DeckPanels;
    public GameObject Tab;
    private List<GameObject> Tabs;
    public GameObject currentDeckPanel;
    public GameObject currentDeckTab;
    private int numberOfDecks = 1;
    public void Start()
    {
        Tabs = new List<GameObject>();
        Tabs.Add(currentDeckTab);
        DeckPanels = new List<GameObject>();
        DeckPanels.Add(currentDeckPanel);
        GetComponent<DeckList>().currentDeck = currentDeckPanel.GetComponent<Deck>().deckData;
        GetComponent<DeckList>().decks.Add(currentDeckPanel.GetComponent<Deck>().deckData);
    }

    public void AddDeck()
    {
        Tabs.ForEach(elem => { Debug.Log(elem); elem.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false); });
        GameObject t = Instantiate(Tab, gameObject.transform.Find("TabsPanel/NewDecksPanel").transform);
        t.transform.Find("Text").GetComponent<Text>().text = "Deck " + ++numberOfDecks;
        Tabs.Add(t);
        GameObject dp = Instantiate(DeckPanel, transform);
        DeckPanels.Add(dp);

        t.GetComponent<TabController>().DeckPanelsController = this;
        t.GetComponent<TabController>().currentDeckPanel = dp;
        currentDeckPanel = dp;

        GetComponent<DeckList>().decks.Add(dp.GetComponent<Deck>().deckData);
        
    }
    public List<GameObject> GetTabs()
    {
        return Tabs;
    }
    public GameObject GetCurrentDeckTab()
    {
        return currentDeckTab;
    }
    public void SetCurrentDeckTab(GameObject t)
    {
        currentDeckTab = t;
    }
    public void SetCurrentDeckPanel(GameObject d)
    {
        currentDeckPanel = d;
    }
    public GameObject GetCurrentDeckPanel()
    {
        return currentDeckPanel;
    }
    public void HideDeckPanel()
    {
        if(currentDeckPanel != null)
        currentDeckPanel.SetActive(false);
    }
    public void ShowDeckPanel()
    {
        if (currentDeckPanel != null)
            currentDeckPanel.SetActive(true);
    }
}
