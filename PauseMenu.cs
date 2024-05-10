using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    Vector2 camPos;
    public static bool GameIsPaused = false;
    private int menuIndex;

    void Start(){
        camPos = GameObject.Find("Camera").transform.position;
    }

    void Awake(){
        camPos = GameObject.Find("Camera").transform.position;
    }

    void Update(){
        transform.position = camPos;
    }
    void OnPause(){
        if(GameIsPaused){
            Resume();
        }
        else{
            Pause();
        }
    }
    void OnSelect(){
        if(GameIsPaused == true){
            if(menuIndex == 1){
                Resume();
            }
            else if(menuIndex == 2){
                LoadMenu();
            }
            else if(menuIndex == 3){
                ResetLevel();
            }
            else if(menuIndex == 4){
                QuitGame();
            }
        }
    }
    public void Resume()
    {
        for(int i = 1; i < 5; i++){
            transform.GetChild(0).GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
        }
        menuIndex = 1;
        Time.timeScale = 1f;
        GameIsPaused = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Pause()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().color = Color.yellow;
        Time.timeScale = 0f;
        GameIsPaused = true;
        menuIndex = 1;
    }
    void OnSelectDown(){
        if(GameIsPaused){
            transform.GetChild(0).GetChild(menuIndex++).gameObject.GetComponent<Image>().color = Color.white;
            if(menuIndex > 4){
                menuIndex = 1;
            }
            transform.GetChild(0).GetChild(menuIndex).gameObject.GetComponent<Image>().color = Color.yellow;
        }
    }
    void OnSelectUp(){
        if(GameIsPaused){
            transform.GetChild(0).GetChild(menuIndex--).gameObject.GetComponent<Image>().color = Color.white;
            if(menuIndex < 1){
                menuIndex = 4;
            }
            transform.GetChild(0).GetChild(menuIndex).gameObject.GetComponent<Image>().color = Color.yellow;
        }
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void ResetLevel(){
        GameObject.Find("Player").GetComponent<PlayerSpawn>().PlayerRespawn();
        Resume();
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
