using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float tdt;
    
    public float speed, acceleration;
    public float xrotationSpeed, yrotationSpeed, zrotationSpeed;
    public float horizontalInput, verticalInput;

    public bool speedUp, speedDown, timonLeft, timonRight;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tdt = Time.deltaTime;

        // get the user's vertical input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * tdt * speed);
        //transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward * tdt * speed, tdt);

        // Z Rotation - tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * zrotationSpeed * tdt * verticalInput);

        // X Rotationssss
        transform.Rotate(Vector3.back * xrotationSpeed * tdt * horizontalInput);

        //speed
        //speedUp = Input.GetKeyDown(KeyCode.P);
        speedUp = Input.GetKey(KeyCode.P);
        speedDown = Input.GetKey(KeyCode.L);

        if (speedUp)
        {
            speed += acceleration * tdt;
        }

        if (speedDown)
        {
            speed -= acceleration * tdt;
        }

        speed = Mathf.Clamp(speed, 5f, 100f);

        //Timon
        timonLeft = Input.GetKey(KeyCode.Comma);
        timonRight = Input.GetKey(KeyCode.Period);

        if (timonLeft)
        {
            transform.Rotate(Vector3.down * yrotationSpeed * tdt);
        }

        if (timonRight)
        {
            transform.Rotate(Vector3.up * yrotationSpeed * tdt);
        }
    }
}
