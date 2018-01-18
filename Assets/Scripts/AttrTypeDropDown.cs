using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttrTypeDropDown : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        string[] classTypeNames = System.Enum.GetNames(typeof(AttrType));
        List<string> names = new List<string>(classTypeNames);
        gameObject.GetComponent<Dropdown>().AddOptions(names);
        
    }
	
}
