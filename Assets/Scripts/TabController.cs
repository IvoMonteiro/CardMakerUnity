using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour {

    public OptionsPanelController PanelController;
    public GameObject currentDeckPanel;


    public void SetCurrentDeckPanel()
    {
        PanelController.currentDeckPanel = currentDeckPanel;
        PanelController.currentDeckPanel.transform.SetAsLastSibling();
    }

}
