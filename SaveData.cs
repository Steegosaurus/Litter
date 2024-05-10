using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string saveName;
    public int treeSquirrelLevel;
    public int groundSquirrelLevel;
    public int flyingSquirrelLevel;
    public bool beatFinalLevel;
    public string lastLevelCleared;

    public SaveData(int treeLev, int groundLev, int flyingLev, bool finLev, string lastLev){
        treeSquirrelLevel = treeLev;
        groundSquirrelLevel = groundLev;
        flyingSquirrelLevel = flyingLev;
        beatFinalLevel = finLev;
        lastLevelCleared = lastLev;
    }
}
