﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item : Card {

    public ItemData data;
    public Effect effect;
    public List<ClassType> restrinctions;
	// Use this for initialization
	void Start () {
        effect = new Effect();
        restrinctions = new List<ClassType>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
