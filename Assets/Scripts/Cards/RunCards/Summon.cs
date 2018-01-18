using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Summon : Card {

    public SummonData data;
    private Effect effect;
    private Character character;

    private List<ClassType> restrinctions;
    // Use this for initialization
    void Start()
    {
        effect = new Effect();
        restrinctions = new List<ClassType>();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
