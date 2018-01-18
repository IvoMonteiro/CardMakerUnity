using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Character : Card {

    public CharacterData data;
    public Dictionary<string, Attribute> attrDict;
    public List<Attribute> attrList;
    public Class charClass;
    public Dictionary<string, Skill> skillDict;
    public List<Skill> skillList;
    


}
