using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);
    private bool cameraSwitch;
    private string cameraMode = "3ra";

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()  //LateUpdate pasa despues de update para evitar que se mueve adelante/atras feo
    {
        transform.position = player.transform.position + offset;        
        cameraSwitch = Input.GetKeyDown(KeyCode.C);
        if (cameraSwitch) CameraSwitch();

    }
        private void CameraSwitch()
    {
        if (cameraMode == "3ra")
        {
            cameraMode = "1ra";
            offset = new Vector3(0, 5, 0);
        }
        else
        {
            cameraMode = "3ra";
            offset = new Vector3(0, 5, -7);

        }
    }
}
