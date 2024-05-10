using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class SceneChange : MonoBehaviour
{
    public string nextSceneName;
    public string thisSceneName;
    public Vector2 newPlayerPosition;
    public bool levelEnder;
    public int levelEndingSaveTree;
    public int levelEndingSaveGround;
    public int levelEndingSaveFlying;
    public string levelEndingSaveName;
    public GameObject saveTrack;
    
    void Awake(){
        saveTrack = GameObject.FindWithTag("SaveTracker");
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            if(other.transform.GetComponent<PlayerInput>().actions["Hold"].ReadValue<float>() == 1f){
                if(levelEnder){
                    int tree;
                    int ground;
                    int fly;
                    if(levelEndingSaveTree != 0){
                        tree = levelEndingSaveTree;
                    }
                    else{
                        tree = saveTrack.GetComponent<SaveTracker>().GetTreeLevel();
                    }
                    if(levelEndingSaveGround != 0){
                        ground = levelEndingSaveGround;
                    }
                    else{
                        ground = saveTrack.GetComponent<SaveTracker>().GetGroundLevel();
                    }
                    if(levelEndingSaveFlying != 0){
                        fly = levelEndingSaveFlying;
                    }
                    else{
                        fly = saveTrack.GetComponent<SaveTracker>().GetFlyLevel();
                    }
                    SaveSystem.SaveGameData(tree, ground, fly, false, saveTrack.GetComponent<SaveTracker>().GetFileNum(), saveTrack.GetComponent<SaveTracker>(), levelEndingSaveName);
                    SceneManager.LoadScene("MapMenu", LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync(thisSceneName);
                    SceneManager.UnloadSceneAsync("Gameplay");
                }
                else{
                    SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync(thisSceneName);
                    other.transform.position = newPlayerPosition;
                    GameObject.Find("Camera").GetComponent<CameraFollow>().ResetCamera();
                    GameObject.Find("Player").GetComponent<PlayerSpawn>().currentScene = nextSceneName;
                    GameObject.Find("Player").transform.position = Vector2.zero;
                    GameObject.Find("Player").GetComponent<PlayerDeath>().ResetSceneObjects();
                }
            }
        }
    }
}
