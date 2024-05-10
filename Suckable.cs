using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suckable : MonoBehaviour
{
    private bool gettingSucked;
    private float suckingSpeed;
    private float suckerMinDistance;
    private Vector2 suckerPosition;
    private Vector2 arrowDirection;
    private Rigidbody2D rb;
    public float launchSpeed;
    public ArrowScript arrow;
    private void Awake(){
        gettingSucked = false;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate(){
        if(gettingSucked){
            if(Vector2.Distance(rb.position, suckerPosition) < suckerMinDistance){
                gettingSucked = false;
                if(this.gameObject.tag == "Player"){
                    this.gameObject.GetComponent<PlayerMovement>().enabled = true;
                    rb.velocity = arrowDirection * launchSpeed;
                }
                else{
                    rb.AddForce(arrowDirection * 500f);
                    rb.gravityScale = 1;
                }
                arrow.StopShooting();
            }
            else{
                rb.MovePosition(Vector2.MoveTowards(rb.position, suckerPosition, suckingSpeed));
            }
        }
    }
    public void GetSucked(Vector2 sp, float suckerSpeed, float amd, Vector2 ad, ArrowScript AS){
        gettingSucked = true;
        suckingSpeed = suckerSpeed;
        suckerMinDistance = amd;
        suckerPosition = sp;
        arrowDirection = ad;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        arrow = AS;
        if(this.gameObject.tag == "Player"){
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }

}
