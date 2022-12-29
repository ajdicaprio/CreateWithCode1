using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOutBounds : MonoBehaviour
{
    private float topBound = 30f;



    void Update()
    {
        if (transform.position.z > topBound)
        {
            gameObject.SetActive(false);
        }


    }
}
