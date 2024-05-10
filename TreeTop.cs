using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeTop : MonoBehaviour
{
    public LayerMask myLayerMask;
    public LayerMask playerLayer;
    Vector3 oldPosition;
    Vector3 newPosition;
    Vector3 lastSpawnPoint;
    Rigidbody2D playerRB;
    PlayerCollisionHandler playerCH;
    GameObject player;
    Vector3 platformVelocity;
    public float topForce;
    float growStartTime;
    public float growTime;
    bool platformMoving;
    float platformMovingUpTime;
    public float platformMovingUpBuffer;
    public GameObject trunkPrefab;
    public Scene gameplayScene;
    public GameObject playerObj;
    public bool waitingToReturnPlayerToGameplay;
    public float returnPlayerTimer;

    void Awake()
    {
        waitingToReturnPlayerToGameplay = false;
        growStartTime = 0f;
        platformMoving = true;
        platformVelocity = new Vector3(0f, 10f, 0f);
        platformMovingUpTime -= Time.deltaTime;
        lastSpawnPoint = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        if(Physics2D.OverlapBox(this.transform.position, new Vector2(2.905f, 1f), 0, playerLayer)){
            if(Physics2D.OverlapBox(this.transform.position, new Vector2(2.905f, 1f), 0, playerLayer).tag != "Feet"){
                player = Physics2D.OverlapBox(this.transform.position, new Vector2(2.905f, 1f), 0, playerLayer).gameObject;
                playerRB = player.GetComponent<Rigidbody2D>();
                playerCH = player.GetComponent<PlayerCollisionHandler>();
                player.transform.position = this.transform.position + (Vector3.up * 2f);
                if(!playerCH.onPlatform){
                    playerCH.onPlatform = true;
                    playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
                    Debug.Log("2");
                    player.transform.parent = this.transform;
                }
            }
            else{
                player = Physics2D.OverlapBox(this.transform.position, new Vector2(2.905f, 2.667f), 0, playerLayer).transform.parent.gameObject;
                playerRB = player.GetComponent<Rigidbody2D>();
                playerCH = player.GetComponent<PlayerCollisionHandler>();
                player.transform.position = this.transform.position + (Vector3.up * 2f);
                if(!playerCH.onPlatform){
                    playerCH.onPlatform = true;
                    playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
                    player.transform.parent = this.transform;
                    Debug.Log("3");
                }
            }
        }
    }

    // Update is called once per frame
    void Update(){
        if(waitingToReturnPlayerToGameplay){
            SceneManager.MoveGameObjectToScene(playerObj, SceneManager.GetSceneByName("Gameplay"));
            waitingToReturnPlayerToGameplay = false;
            
        }
        if(platformMoving){
            newPosition = transform.position + (new Vector3(0, 1, 0) * topForce * Time.deltaTime);
            oldPosition = transform.position;
            if((growStartTime >= growTime)||(Physics2D.OverlapBox(transform.position + (Vector3.up * 1.3f), new Vector2(2, 0.1f), 0, myLayerMask))){
                platformMoving = false;
            }
            else{
                growStartTime += Time.deltaTime;
                oldPosition = transform.position;
                transform.position = newPosition;
                platformMovingUpTime = platformMovingUpBuffer;
                if((transform.position - lastSpawnPoint).y >= 0.4f){
                    Instantiate(trunkPrefab, lastSpawnPoint, Quaternion.identity);
                    lastSpawnPoint = transform.position;
                }
            }
        }
        else{
            if(platformMovingUpTime > 0){
                platformMovingUpTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Feet"){
            playerRB = other.transform.parent.GetComponent<Rigidbody2D>();
            playerCH = other.transform.parent.GetComponent<PlayerCollisionHandler>();
            if(!playerCH.onPlatform){
                Debug.Log("1");
                playerCH.onPlatform = true;
                playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
                other.transform.parent.parent = this.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Feet"){
            if(platformMoving){
                playerRB.AddForce(platformVelocity * 25f);
            }
            Debug.Log("4");
            playerCH.onPlatform = false;
            platformMoving = false;
            ReleasePlayer();
            playerObj = other.transform.parent.gameObject;
            waitingToReturnPlayerToGameplay = true;
        }
    }

    public void ReleasePlayer(){
        Debug.Log(this.gameObject);
        this.transform.GetChild(2).parent = null;
    }
}
