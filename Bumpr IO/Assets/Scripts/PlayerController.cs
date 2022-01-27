using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float movementSpeed = 20;
    public float rotationSpeed = 2;
    private Rigidbody playerRb;
    public GameManager gameManagerReference;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        //transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * rotationSpeed);


        //horizontalInput = Input.GetAxis("Horizontal");
        ////playerRb.AddForce(Vector3.forward * movementSpeed);
        //playerRb.AddRelativeForce(Vector3.forward * Time.deltaTime * movementSpeed);
        ////playerRb.AddRelativeTorque(Vector3.up * rotationSpeed * horizontalInput);
        //playerRb.AddTorque(Vector3.up * rotationSpeed * horizontalInput);
        //if (horizontalInput == 0)
        //{
        //    playerRb.angularVelocity = new Vector3(0, 0, 0);
        //}

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * verticalInput * movementSpeed);
        playerRb.AddForce(Vector3.right * horizontalInput * movementSpeed);
    }

    public void InitializePlayer(GameManager gameManager)
    {
        gameManagerReference = gameManager;
    }
}