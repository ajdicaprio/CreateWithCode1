using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offsetSide = new Vector3(50f, 2.75f, 1f);
    private Vector3 offsetFront = new Vector3(0, 14f, -28f);

    public string cameraMode = "Side";
    public bool goCamera = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cameraMode == "Side")
            {
                cameraMode = "Front";
                goCamera = true;
            }
            else
            {
                cameraMode = "Side";
                goCamera = true;
            }
        }

        if (cameraMode == "Side")
        {
            transform.position = plane.transform.position + offsetSide;
        }
        if (cameraMode == "Front")
        {
            transform.localPosition = plane.transform.position + offsetFront;
        }
    }
}
