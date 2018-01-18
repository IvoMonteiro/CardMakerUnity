using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClassTypeDropDown : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        string[] classTypeNames = System.Enum.GetNames(typeof(ClassType));
        List<string> names = new List<string>(classTypeNames);
        gameObject.GetComponent<Dropdown>().AddOptions(names);
        
    }
	
}
