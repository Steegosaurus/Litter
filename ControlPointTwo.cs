using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlPointTwo : MonoBehaviour
{
    public Transform playerT;
    private PlayerInput playerI;
    private SpriteRenderer playerS;
    private float tubeTimer;
    [SerializeField]
    private Transform[] controlPoints;
    private Vector2 lastPos;
    private Vector2 velo;
    public float playerTubeLaunchPower;
    public float itemTubeLaunchPower;
    void Update(){
        if(transform.parent.GetComponent<PlasticTube>().playerInTubeTwo){
            if(tubeTimer < 1){
                Vector2 newPosition = Mathf.Pow(1 - tubeTimer, 3) * controlPoints[3].position +
                3 * Mathf.Pow(1 - tubeTimer, 2) * tubeTimer * controlPoints[2].position +
                3 * (1 - tubeTimer) * Mathf.Pow(tubeTimer, 2) * controlPoints[1].position +
                Mathf.Pow(tubeTimer, 3) * controlPoints[0].position;

                playerT.position = newPosition;

                velo = (newPosition - lastPos).normalized;

                lastPos = newPosition;

                tubeTimer += Time.deltaTime;
            }
            else{
                transform.parent.GetComponent<PlasticTube>().playerInTubeTwo = false;
                if(playerI){    
                    playerI.enabled = true;
                    playerT.GetComponent<Rigidbody2D>().velocity =  new Vector2(velo.x * playerTubeLaunchPower * 3 / 4, velo.y * playerTubeLaunchPower);
                }
                else{
                    playerT.GetComponent<Rigidbody2D>().velocity = velo * itemTubeLaunchPower;
                }
                transform.parent.GetComponent<PlasticTube>().lastTimeTravelled = 0.25f;
                playerS.enabled = true;
            }
        }

        
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player" && transform.parent.GetComponent<PlasticTube>().lastTimeTravelled < 0 && !transform.parent.GetComponent<PlasticTube>().playerInTubeOne && !transform.parent.GetComponent<PlasticTube>().playerInTubeTwo){
            if(!other.GetComponent<PlayerItemHandler>().holdingItem){
                tubeTimer = 0;
                transform.parent.GetComponent<PlasticTube>().playerInTubeTwo = true;
                playerI = other.transform.GetComponent<PlayerInput>();
                playerI.enabled = false;
                playerT = other.transform;
                playerS = other.transform.GetComponent<SpriteRenderer>();
                playerS.enabled = false;
            }
        }
        else if((other.tag == "Acorn" || other.tag == "FloatingAcorn") && transform.parent.GetComponent<PlasticTube>().lastTimeTravelled < 0 && !transform.parent.GetComponent<PlasticTube>().playerInTubeOne && !transform.parent.GetComponent<PlasticTube>().playerInTubeTwo){
                tubeTimer = 0;
                transform.parent.GetComponent<PlasticTube>().playerInTubeTwo = true;
                playerT = other.transform;
                playerS = other.GetComponent<SpriteRenderer>();
                playerS.enabled = false;
        }
    }
}
