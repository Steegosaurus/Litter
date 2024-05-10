using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private int menuIndex;
    void Awake(){
        menuIndex = 2;
        transform.GetChild(0).GetChild(2).GetComponent<Image>().color = Color.yellow;
        SceneManager.LoadScene("SaveManager", LoadSceneMode.Additive);
    }

    void OnSelect(){
        if(menuIndex == 2){
            StartGame();
        }
        else if(menuIndex == 3){
            LoadGame();
        }
        else if(menuIndex == 4){
            OpenSettings();
        }
        else if(menuIndex == 5){
            QuitGame();
        }
    }
    public void StartGame(){
        transform.GetChild(1).GetChild(0).gameObject.active = true;
        transform.GetChild(0).gameObject.active = false;
    }

    public void LoadGame(){
        transform.GetChild(1).GetChild(1).gameObject.active = true;
        transform.GetChild(0).gameObject.active = false;
    }

    public void OpenSettings(){
        Debug.Log("Opening Settings");
    }

    public void QuitGame(){
        Application.Quit();
    }

    void OnSelectDown(){
        transform.GetChild(0).GetChild(menuIndex++).gameObject.GetComponent<Image>().color = Color.white;
        if(menuIndex > 5){
            menuIndex = 2;
        }
        transform.GetChild(0).GetChild(menuIndex).gameObject.GetComponent<Image>().color = Color.yellow;
    }
    void OnSelectUp(){
        transform.GetChild(0).GetChild(menuIndex--).gameObject.GetComponent<Image>().color = Color.white;
        if(menuIndex < 2){
            menuIndex = 5;
        }
        transform.GetChild(0).GetChild(menuIndex).gameObject.GetComponent<Image>().color = Color.yellow;
    }

    void OnPause(){
        transform.GetChild(1).GetChild(0).gameObject.active = false;
        transform.GetChild(1).GetChild(1).gameObject.active = false;
        transform.GetChild(0).gameObject.active = true;
    }
}
