using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class jtPlatRight : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            if(col.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0f || col.gameObject.GetComponent<PlayerInput>().actions["Move"].ReadValue<Vector2>().x < 0){
                GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else if(col.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0f || col.gameObject.GetComponent<PlayerInput>().actions["Move"].ReadValue<Vector2>().x > 0){
                GetComponent<BoxCollider2D>().isTrigger = true;
                GetComponent<Animator>().Play("rightdoor_open");
            }
        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "Player"){
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void StopOpening(){
        GetComponent<Animator>().Play("rightdoor_idle");
    }
}
