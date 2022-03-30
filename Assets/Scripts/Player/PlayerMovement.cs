using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody playerRb;
    [SerializeField] Transform playerCamera;
    CharacterController characterController;
    
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float turnSpeed = 0.1f;
    float smoothVelocity ;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3 (hAxis,0,vAxis);

        if(moveVector.magnitude >= 0.01f)
        {
            float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) *Mathf.Rad2Deg + playerCamera.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, turnSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(Vector3.Normalize(moveDir) * moveSpeed * Time.deltaTime);

        }
    }
}
