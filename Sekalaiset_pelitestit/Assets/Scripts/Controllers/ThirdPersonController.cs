using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour { 

    public float moveSpeed = 12;
    public Vector3 moveVector; 

    Rigidbody rigidBody;
    float moveX;
    float moveZ;

    bool isTouching = false;
    public float jumpPower;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();

        if (rigidBody == null)
            Debug.LogError("RigidBody could not be found.");
    }

   
    void Update() {

        PlayerMovement();
    }


    void PlayerMovement() {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        moveVector = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector, Space.Self);

        if (Input.GetKeyDown("space")) { //jump
            rigidBody.AddForce(new Vector3(0, jumpPower, 0) * 50);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        isTouching = true;
    }
    private void OnCollisionExit(Collision collision) {
        isTouching = false;
    }


}
