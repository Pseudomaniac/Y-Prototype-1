using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody playerRb;
    
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float turnSpeed = 20f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void TurnPlayer(Vector3 direction)
    {
        transform.Rotate(Vector3.up*Time.deltaTime*turnSpeed*Input.GetAxis("Horizontal"));
    }

    void MovePlayer()
    {
        Vector3 moveVector = new Vector3 (moveSpeed*Time.deltaTime*Input.GetAxis("Horizontal"),0,moveSpeed*Time.deltaTime*Input.GetAxis("Vertical"));
        Vector3 normalisedMoveVector = moveVector.normalized;
        transform.Translate(0,0,moveSpeed*Time.deltaTime*Input.GetAxis("Vertical"));

    }
}
