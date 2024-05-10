using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Vector2 arrowDir;
    private Vector2 suckVector;
    private Rigidbody2D playerRB;
    private PlayerMovement playerMovement;
    public float suckSpeed = 0.1f;
    public float minSuckDistance = 0.05f;
    public float animationTime;
    public float animationTimer;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.GetComponent<Suckable>() != null){
            other.gameObject.GetComponent<Suckable>().GetSucked(transform.position, suckSpeed, minSuckDistance, arrowDir, this.gameObject.GetComponent<ArrowScript>());
            this.gameObject.GetComponent<Animator>().Play("trashcan_fire");
        }
    }

    public void StopShooting(){
        this.gameObject.GetComponent<Animator>().Play("trashcan_idle");
    }
}
