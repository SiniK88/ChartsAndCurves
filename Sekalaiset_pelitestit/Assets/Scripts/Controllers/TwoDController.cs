using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDController : MonoBehaviour
{
    public float moveSpeed = 12;
    public Vector3 moveVector;
    public Camera mainCamera;

    Vector3 cameraPos;

    Transform t;
    public bool isTouching; 
    Rigidbody rigidBody;
    float moveX;
    float moveZ;

    public float jumpPower;
    void Start()
    {
        t = this.GetComponent<Transform>();
        rigidBody = this.GetComponent<Rigidbody>();

        if (rigidBody == null)
            Debug.LogError("RigidBody could not be found.");

        if (mainCamera) {
            cameraPos = mainCamera.transform.position;
        }
    }

    void Update() {
        if (isTouching  && Input.GetKeyDown(KeyCode.Space)) { //jump
            rigidBody.AddForce(new Vector3(0, jumpPower, 0) * 50);
            isTouching = false;
        }

        PlayerMovement();
        // Camera follow
        if (mainCamera) {
            mainCamera.transform.position = new Vector3(t.position.x, t.position.y, cameraPos.z);

        }
    }

    void PlayerMovement() {
        moveX = Input.GetAxis("Horizontal");
        //moveZ = Input.GetAxis("Vertical");
        moveVector = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector, Space.Self);

    }


    void OnCollisionStay() {
        print(" koskeeko se");
        isTouching = true;
    }

    private void OnCollisionEnter(Collision collision) {
        print("koskee");
        isTouching = true;
    }

    private void OnCollisionExit(Collision collision) {
        print("Ei koske");
        isTouching = false;
    }

}


