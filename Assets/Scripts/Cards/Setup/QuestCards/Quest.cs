using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest : Card
{
    public QuestData data;
    public List<CharacterData> minions;
    public List<ClassType> restrictions;
    public GameObject currentGarrison;

}
