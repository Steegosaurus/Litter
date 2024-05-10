using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTracker : MonoBehaviour
{
    public string currFile;
    public int flyLevel;
    public int groundLevel;
    public int treeLevel;
    public string lastLevelCleared;
    public int fileNum;

    public void ChangeSaveFile(string newFile){
        currFile = newFile;
    }

    public string GetSaveFile(){
        return currFile;
    }

    public void ChangeTreeLevel(int newTree){
        treeLevel = newTree;
    }

    public int GetTreeLevel(){
        return treeLevel;
    }

    public void ChangeGroundLevel(int newGround){
        groundLevel = newGround;
    }

    public int GetGroundLevel(){
        return groundLevel;
    }

    public void ChangeFlyLevel(int newFly){
        flyLevel = newFly;
    }

    public int GetFlyLevel(){
        return flyLevel;
    }

    public void ChangeLastLevel(string last){
        lastLevelCleared = last;
    }

    public string GetLastLevel(){
        return lastLevelCleared;
    }

    public void ChangeFileNum(int newFileNum){
        fileNum = newFileNum;
    }

    public int GetFileNum(){
        return fileNum;
    }
}
