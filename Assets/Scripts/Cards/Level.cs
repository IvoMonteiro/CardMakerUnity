using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public int current_level = 0;
    public int current_xp = 0;
    public int[] toLevelUp;


    public void FixedUpdate()
    {
        if (current_xp >= toLevelUp[current_level])
            current_level++;
    }

    public void AddXP()
    {
        current_xp++;
    }

    public void AddXP(int xp)
    {
        current_xp += xp;
    }
}
