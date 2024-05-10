using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticTube : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;
    private Vector2 gizmosPosition;
    Vector2 prevPosition;
    public GameObject pipePiece;
    private GameObject firstPiece;
    public Sprite firstPiecePrefab;
    public Sprite lastPiecePrefab;
    public float lastTimeTravelled;
    public bool playerInTubeOne;
    public bool playerInTubeTwo;
    public float pipeLength;
    private void OnDrawGizmos()
    {
        for(float t = 0; t <= 1; t += 0.01f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
            3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
            3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
            Mathf.Pow(t, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
            new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));

        Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y),
            new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));
    }

    private void Awake(){
        pipeLength = Vector3.Distance(transform.GetChild(0).position, transform.GetChild(3).position);
        for(float t = 0; t <= 1; t += 0.02f)
        {
            Vector2 piecePosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
            3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
            3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
            Mathf.Pow(t, 3) * controlPoints[3].position;

            GameObject piece = Instantiate(pipePiece, piecePosition, Quaternion.identity, transform);
            if(t == 0){
                firstPiece = piece;
                prevPosition = piecePosition;
            }
            else if(t == 0.02f){
                float firstRot = 57.296f * Mathf.Atan((prevPosition.y - piecePosition.y)/(prevPosition.x - piecePosition.x));
                firstPiece.transform.eulerAngles = new Vector3(0, 0, firstRot);
                firstPiece.GetComponent<SpriteRenderer>().sprite = firstPiecePrefab;
                if(piecePosition.x < prevPosition.x){
                    piece.transform.localScale = new Vector3(-1f, piece.transform.localScale.y, piece.transform.localScale.z);
                }
                else{
                    firstPiece.transform.localScale = new Vector3(-1f, firstPiece.transform.localScale.y, firstPiece.transform.localScale.z);
                }
                piece.transform.eulerAngles = new Vector3(0, 0, 57.296f * Mathf.Atan((prevPosition.y - piecePosition.y)/(prevPosition.x - piecePosition.x)));
                prevPosition = piecePosition;
            }
            else if((t + 0.02f) > 1){
                float lastRot = 57.296f * Mathf.Atan((prevPosition.y - piecePosition.y)/(prevPosition.x - piecePosition.x));
                piece.transform.eulerAngles = new Vector3(0, 0, lastRot);
                piece.GetComponent<SpriteRenderer>().sprite = lastPiecePrefab;
                if(piecePosition.x > prevPosition.x){
                    piece.transform.localScale = new Vector3(-1f, piece.transform.localScale.y, piece.transform.localScale.z);
                }
                prevPosition = piecePosition;
            }
            else{
                if(piecePosition.x < prevPosition.x){
                    piece.transform.localScale = new Vector3(-1f, piece.transform.localScale.y, piece.transform.localScale.z);
                }
                piece.transform.eulerAngles = new Vector3(0, 0, 57.296f * Mathf.Atan((prevPosition.y - piecePosition.y)/(prevPosition.x - piecePosition.x)));
                prevPosition = piecePosition;
            }

        }
        playerInTubeOne = false;
        playerInTubeTwo = false;
    }

    /*
    private void Awake(){
        pipeLength = Vector3.Distance(transform.GetChild(0).position, transform.GetChild(3).position);
        for(float t = 0; t <= pipeLength; t += pipeLength / 40)
        {
            Vector2 piecePosition = Mathf.Pow(1 - t/pipeLength, 3) * controlPoints[0].position +
            3 * Mathf.Pow(1 - t/pipeLength, 2) * t/pipeLength * controlPoints[1].position +
            3 * (1 - t/pipeLength) * Mathf.Pow(t/pipeLength, 2) * controlPoints[2].position +
            Mathf.Pow(t/pipeLength, 3) * controlPoints[3].position;

            GameObject piece = Instantiate(pipePiece, piecePosition, Quaternion.identity, transform);
            if(t == 0){
                firstPiece = piece;
                prevPosition = piecePosition;
                firstPiece.GetComponent<SpriteRenderer>().sprite = firstPiecePrefab;
            }
            else if(t == pipeLength / 40){
                firstPiece.transform.eulerAngles = new Vector3(0, 0, 57.296f * Mathf.Atan((prevPosition.y - piecePosition.y)/(prevPosition.x - piecePosition.x)));
                piece.transform.eulerAngles = new Vector3(0, 0, 57.296f * Mathf.Atan((prevPosition.y - piecePosition.y)/(prevPosition.x - piecePosition.x)));
                prevPosition = piecePosition;
            }
            else if((t/pipeLength + pipeLength/40) > 1){
                piece.GetComponent<SpriteRenderer>().sprite = lastPiecePrefab;
                piece.transform.eulerAngles = new Vector3(0, 0, 57.296f * Mathf.Atan((prevPosition.y - piecePosition.y)/(prevPosition.x - piecePosition.x)));
                prevPosition = piecePosition;
            }
            else{
                piece.transform.eulerAngles = new Vector3(0, 0, 57.296f * Mathf.Atan((prevPosition.y - piecePosition.y)/(prevPosition.x - piecePosition.x)));
                prevPosition = piecePosition;
            }

        }
        playerInTubeOne = false;
        playerInTubeTwo = false;
    }
    */
    
    void Update(){
        lastTimeTravelled -= Time.deltaTime;
    }
}
