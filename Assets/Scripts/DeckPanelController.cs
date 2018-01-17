using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPanelController : MonoBehaviour {

    public OptionsPanelController PanelController;
    public GameObject DeckPanel;
    private List<GameObject> DeckPanels;
    public GameObject Tab;
    private List<GameObject> Tabs;

    public void Start()
    {
        Tabs = new List<GameObject>();
        DeckPanels = new List<GameObject>();
    }

    public void AddDeck()
    {
        GameObject t = Instantiate(Tab, gameObject.transform.Find("Panel/TabsPanel").transform);
        Tabs.Add(t);
        GameObject dp = Instantiate(DeckPanel, transform);
        DeckPanels.Add(dp);

        t.GetComponent<TabController>().PanelController = PanelController;
        t.GetComponent<TabController>().currentDeckPanel = dp;
        PanelController.currentDeckPanel = dp;

        Deck d = Instantiate(dp.GetComponent<Deck>());
        GetComponent<DeckList>().decks.Add(d);
    }

    public void SetCurrentDeckPanel(GameObject d)
    {
        PanelController.GetComponent<OptionsPanelController>().currentDeckPanel.SetActive(false);
    }
}
