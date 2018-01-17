using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabController : MonoBehaviour {

    public DeckPanelsController DeckPanelsController;
    public GameObject currentDeckPanel;

    public void SetCurrentDeckPanel()
    {
        transform.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
        DeckPanelsController.GetCurrentDeckPanel().SetActive(false);
        DeckPanelsController.SetCurrentDeckPanel(currentDeckPanel);
        DeckPanelsController.GetCurrentDeckPanel().SetActive(true);
        DeckPanelsController.GetCurrentDeckPanel().transform.SetAsLastSibling();
    }

}
