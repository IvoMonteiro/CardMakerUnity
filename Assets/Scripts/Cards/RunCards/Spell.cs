using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Spell : Card
{
    public SpellData data;
    private Effect effect;
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
