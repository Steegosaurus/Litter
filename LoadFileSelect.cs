using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFileSelect : MonoBehaviour
{
    public SaveData saveData;
    public GameObject saveTrack;

    void Awake(){
        saveTrack = GameObject.FindWithTag("SaveTracker");
    }
    public void LoadSaveFileOne(){
        SceneManager.LoadScene("MapMenu", LoadSceneMode.Additive);
        saveData = SaveSystem.LoadGameOne();
        saveTrack.GetComponent<SaveTracker>().ChangeFileNum(1);
        saveTrack.GetComponent<SaveTracker>().ChangeTreeLevel(saveData.treeSquirrelLevel);
        saveTrack.GetComponent<SaveTracker>().ChangeGroundLevel(saveData.groundSquirrelLevel);
        saveTrack.GetComponent<SaveTracker>().ChangeFlyLevel(saveData.flyingSquirrelLevel);
        saveTrack.GetComponent<SaveTracker>().ChangeLastLevel(saveData.lastLevelCleared);
        SceneManager.UnloadScene("Main Menu");
    }

    public void LoadSaveFileTwo(){
        SceneManager.LoadScene("MapMenu", LoadSceneMode.Additive);
        SaveSystem.SaveGameData(0, 0, 0, false, 2, GameObject.FindWithTag("SaveTracker").GetComponent<SaveTracker>(), "tutorial");
        SceneManager.UnloadScene("Main Menu");
    }

    public void LoadSaveFileThree(){
        SceneManager.LoadScene("MapMenu", LoadSceneMode.Additive);
        SaveSystem.SaveGameData(0, 0, 0, false, 3, GameObject.FindWithTag("SaveTracker").GetComponent<SaveTracker>(), "tutorial");
        SceneManager.UnloadScene("Main Menu");
    }
}
