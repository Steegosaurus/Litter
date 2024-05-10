using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCannon : MonoBehaviour
{
    public float cannonPlayerPower;
    public float cannonAcornPower;
    public Vector2 cannonVector;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Acorn" || other.tag == "FloatingAcorn"){
            other.gameObject.GetComponent<Rigidbody2D>().velocity = cannonAcornPower * cannonVector;
        }
        else if(other.tag == "Player"){
            other.gameObject.GetComponent<Rigidbody2D>().velocity = cannonPlayerPower * cannonVector;
        }
    }
}
