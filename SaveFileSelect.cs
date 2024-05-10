using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveFileSelect : MonoBehaviour
{
    public void StartSaveFileOne(){
        SceneManager.LoadScene("MapMenu", LoadSceneMode.Additive);
        SaveSystem.SaveGameData(0, 0, 0, false, 1, GameObject.FindWithTag("SaveTracker").GetComponent<SaveTracker>(), "tutorial");
        SceneManager.UnloadScene("Main Menu");
    }

    public void StartSaveFileTwo(){
        SceneManager.LoadScene("MapMenu", LoadSceneMode.Additive);
        SaveSystem.SaveGameData(0, 0, 0, false, 2, GameObject.FindWithTag("SaveTracker").GetComponent<SaveTracker>(), "tutorial");
        SceneManager.UnloadScene("Main Menu");
    }

    public void StartSaveFileThree(){
        SceneManager.LoadScene("MapMenu", LoadSceneMode.Additive);
        SaveSystem.SaveGameData(0, 0, 0, false, 3, GameObject.FindWithTag("SaveTracker").GetComponent<SaveTracker>(), "tutorial");
        SceneManager.UnloadScene("Main Menu");
    }
}
