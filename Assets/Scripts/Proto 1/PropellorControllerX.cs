using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellorControllerX : MonoBehaviour
{
    [SerializeField] private float propellorRotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * propellorRotateSpeed);
    }
}
