using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

//PlayerSpawn has functions that respawn the player
public class PlayerSpawn : MonoBehaviour
{
    public Vector2 spawnPoint;
    public string currentScene;
    Rigidbody2D rb;
    PlayerMovement playerMovement;
    PlayerItemHandler playerItem;
    PlayerStateManager playerState;
    PlayerDeath playerDeath;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        playerItem = GetComponent<PlayerItemHandler>();
        playerState = GetComponent<PlayerStateManager>();
        playerDeath = GetComponent<PlayerDeath>();
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void Update(){
        if(SceneManager.GetSceneByName("MapMenu").name != null){
            for(int i = 0; i < SceneManager.sceneCount; i++){
                if(!(SceneManager.GetSceneAt(i).name == "Gameplay" || SceneManager.GetSceneAt(i).name == "SaveManager" || SceneManager.GetSceneAt(i).name == "MapMenu"
                || SceneManager.GetSceneAt(i).name == "Gameplay")){
                    currentScene = SceneManager.GetSceneAt(i).name;
                    SceneManager.UnloadSceneAsync("MapMenu");
                }
            }
        }
    }

    //PlayerRespawn is called from the animator component on the player andwhen the player respawns, 
    //we enable all the things we disabled in PlayerDie
    public void PlayerRespawn(){
        //Reset everything in the scene
        playerDeath.ResetSceneObjects();

        //Change the state of the player
        playerState.ChangeState(playerState.playerIdle);

        //Moves the player
        // transform.position = spawnPoint;
        transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;

        //Enabling the player to be able to move and interact with the scene
        playerMovement.enabled = true;
        playerItem.canHoldItem = true;
        playerItem.holdingItem = false;
        playerItem.itemLocked = false;
        GetComponent<PlayerInput>().enabled = true;

        //Reload the currentScene
        // currentScene = SceneManager.GetActiveScene().name;
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);

        //Reset the Camera
        GameObject.Find("Camera").GetComponent<CameraFollow>().ResetCamera();
    }

    //OnReset is called when the reset button from the pause menu is pressed
    void OnReset(){
        PlayerRespawn();
    }
}
