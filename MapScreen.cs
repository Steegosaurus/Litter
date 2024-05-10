using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapScreen : MonoBehaviour
{
    PlayerInput playerInput;
    Image image;
    public Sprite[] sprites;
    bool spriteSet;
    bool waitingForAwake;
    GameObject saveObj;
    public string currLevel;
    SaveTracker currSave;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        image = transform.GetChild(0).GetComponent<Image>();
        spriteSet = false;
        waitingForAwake = false;

        for(int i = 1; i < 11; i++){
            transform.GetChild(i).GetComponent<Animator>().Play("button_NF");
        }
    }

    void Update(){
        if(!waitingForAwake){
            saveObj = GameObject.FindWithTag("SaveTracker");
            waitingForAwake = true;
        }
        else if(!spriteSet){
            currSave = saveObj.GetComponent<SaveTracker>();
            image.sprite = SetMapImage(currSave.GetGroundLevel(), currSave.GetFlyLevel(), currSave.GetTreeLevel());

            currLevel = currSave.GetLastLevel();
            if(currSave.GetLastLevel() == "tree_1"){
                transform.GetChild(4).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "tree_2"){
                transform.GetChild(5).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "tree_3"){
                transform.GetChild(6).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "ground_1"){
                transform.GetChild(2).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "ground_2"){
                transform.GetChild(1).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "ground_3"){
                transform.GetChild(3).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "flying_1"){
                transform.GetChild(7).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "flying_2"){
                transform.GetChild(8).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "flying_3"){
                transform.GetChild(9).GetComponent<Animator>().Play("button_F");
            }
            else if(currSave.GetLastLevel() == "tutorial"){
                transform.GetChild(10).GetComponent<Animator>().Play("button_F");
            }

            spriteSet = true;
        }
    }

    void OnSelectRight(){
        if(currLevel == "ground_3"){
            currLevel = "ground_2";
            transform.GetChild(3).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(1).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "ground_2"){
            currLevel = "ground_1";
            transform.GetChild(1).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(2).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "ground_1"){
            currLevel = "tutorial";
            transform.GetChild(2).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(10).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "flying_2" && currSave.GetFlyLevel() > 2){
            currLevel = "flying_3";
            transform.GetChild(9).GetComponent<Animator>().Play("button_F");
            transform.GetChild(8).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "tree_2" && currSave.GetTreeLevel() > 2){
            currLevel = "tree_3";
            transform.GetChild(5).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(6).GetComponent<Animator>().Play("button_F");
        }
    }

    void OnSelectLeft(){
        if(currLevel == "ground_2" && currSave.GetGroundLevel() > 2){
            currLevel = "ground_3";
            transform.GetChild(3).GetComponent<Animator>().Play("button_F");
            transform.GetChild(1).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "ground_1" && currSave.GetGroundLevel() > 1){
            currLevel = "ground_2";
            transform.GetChild(1).GetComponent<Animator>().Play("button_F");
            transform.GetChild(2).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "tutorial" && currSave.GetGroundLevel() > 0){
            currLevel = "ground_1";
            transform.GetChild(2).GetComponent<Animator>().Play("button_F");
            transform.GetChild(10).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "flying_3"){
            currLevel = "flying_2";
            transform.GetChild(9).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(8).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "tree_3"){
            currLevel = "tree_2";
            transform.GetChild(5).GetComponent<Animator>().Play("button_F");
            transform.GetChild(6).GetComponent<Animator>().Play("button_NF");
        }
    }

    void OnSelectUp(){
        if(currLevel == "tree_2"){
            currLevel = "tree_1";
            transform.GetChild(4).GetComponent<Animator>().Play("button_F");
            transform.GetChild(5).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "tree_3"){
            currLevel = "tree_2";
            transform.GetChild(5).GetComponent<Animator>().Play("button_F");
            transform.GetChild(6).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "ground_2"){
            currLevel = "ground_1";
            transform.GetChild(2).GetComponent<Animator>().Play("button_F");
            transform.GetChild(1).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "tutorial" && currSave.GetFlyLevel() > 0){
            currLevel = "flying_1";
            transform.GetChild(7).GetComponent<Animator>().Play("button_F");
            transform.GetChild(10).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "flying_1" && currSave.GetFlyLevel() > 1){
            currLevel = "flying_2";
            transform.GetChild(8).GetComponent<Animator>().Play("button_F");
            transform.GetChild(7).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "flying_2" && currSave.GetFlyLevel() > 2){
            currLevel = "flying_3";
            transform.GetChild(9).GetComponent<Animator>().Play("button_F");
            transform.GetChild(8).GetComponent<Animator>().Play("button_NF");
        }
        else if(currLevel == "tree_1"){
            currLevel = "tutorial";
            transform.GetChild(10).GetComponent<Animator>().Play("button_F");
            transform.GetChild(4).GetComponent<Animator>().Play("button_NF");
        }
    }

    void OnSelectDown(){
        if(currLevel == "tree_1" && currSave.GetTreeLevel() > 1){
            currLevel = "tree_2";
            transform.GetChild(4).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(5).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "tree_2" && currSave.GetTreeLevel() > 2){
            currLevel = "tree_3";
            transform.GetChild(5).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(6).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "ground_1" && currSave.GetGroundLevel() > 1){
            currLevel = "ground_2";
            transform.GetChild(2).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(1).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "flying_1"){
            currLevel = "tutorial";
            transform.GetChild(7).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(10).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "flying_2"){
            currLevel = "flying_1";
            transform.GetChild(8).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(7).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "flying_3"){
            currLevel = "flying_2";
            transform.GetChild(9).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(8).GetComponent<Animator>().Play("button_F");
        }
        else if(currLevel == "tutorial" && currSave.GetTreeLevel() > 0){
            currLevel = "tree_1";
            transform.GetChild(10).GetComponent<Animator>().Play("button_NF");
            transform.GetChild(4).GetComponent<Animator>().Play("button_F");
        }
    }

    void OnSelect(){
        if(currLevel == "tutorial"){
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
        }
        else if(currLevel == "tree_1"){
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
            SceneManager.LoadScene("level_1_1", LoadSceneMode.Additive);
        }
        else if(currLevel == "tree_2"){
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
            SceneManager.LoadScene("level_2_1", LoadSceneMode.Additive);
        }
        else if(currLevel == "tree_3"){
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
            SceneManager.LoadScene("level_3_1", LoadSceneMode.Additive);
        }
    }

    void OnPause(){
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
        SceneManager.UnloadScene("MapMenu");
    }

    Sprite SetMapImage(int ground, int flying, int tree){
        if(ground == 1){
            if(flying == 1){
                if(tree == 1){
                    return sprites[0];
                }
                else if(tree == 2){
                    return sprites[12];
                }
                else if(tree == 3){
                    return sprites[18];
                }
                else{
                    return null;
                }
            }
            else if(flying == 2){
                if(tree == 1){
                    return sprites[1];
                }
                else if(tree == 2){
                    return sprites[13];
                }
                else if(tree == 3){
                    return sprites[19];
                }
                else{
                    return null;
                }
            }
            else if(flying == 3){
                if(tree == 1){
                    return sprites[2];
                }
                else if(tree == 2){
                    return sprites[14];
                }
                else if(tree == 3){
                    return sprites[20];
                }
                else{
                    return null;
                }
            }
            else{
                return null;
            }
        }
        else if(ground == 2){
            if(flying == 1){
                if(tree == 1){
                    return sprites[3];
                }
                else if(tree == 2){
                    return sprites[15];
                }
                else if(tree == 3){
                    return sprites[21];
                }
                else{
                    return null;
                }
            }
            else if(flying == 2){
                if(tree == 1){
                    return sprites[5];
                }
                else if(tree == 2){
                    return sprites[17];
                }
                else if(tree == 3){
                    return sprites[23];
                }
                else{
                    return null;
                }
            }
            else if(flying == 3){
                if(tree == 1){
                    return sprites[6];
                }
                else if(tree == 2){
                    return sprites[9];
                }
                else if(tree == 3){
                    return sprites[24];
                }
                else{
                    return null;
                }
            }
            else{
                return null;
            }
        }
        else if(ground == 3){
            if(flying == 1){
                if(tree == 1){
                    return sprites[4];
                }
                else if(tree == 2){
                    return sprites[16];
                }
                else if(tree == 3){
                    return sprites[22];
                }
                else{
                    return null;
                }
            }
            else if(flying == 2){
                if(tree == 1){
                    return sprites[7];
                }
                else if(tree == 2){
                    return sprites[10];
                }
                else if(tree == 3){
                    return sprites[25];
                }
                else{
                    return null;
                }
            }
            else if(flying == 3){
                if(tree == 1){
                    return sprites[8];
                }
                else if(tree == 2){
                    return sprites[11];
                }
                else if(tree == 3){
                    return sprites[26];
                }
                else{
                    return null;
                }
            }
            else{
                return null;
            }
        }
        else{
            if(ground == 0 && flying == 0 && tree == 0){
                return sprites[27];
            }
            else{
                return null;
            }
        }
    }
}
