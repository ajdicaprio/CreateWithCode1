using System;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;
    private float leftBound = -22f;
    private float rightBound = 22f;

    public static event Action QuePasoConLasVidas;
    //public static event Action<int> PasoConLasVidas; //si es con argumento

        
    void Update()
    {
        //Lo pasé a PizzaOutBounds para usar el ObjectPooler
        //if (transform.position.z > topBound)
        //{
        //    Destroy(gameObject);
        //    //QuePasoConLasVidas?.Invoke(); //si es con argumento lo pasas en los parentesis
        //}

        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            QuePasoConLasVidas?.Invoke();
        }

        else if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
            QuePasoConLasVidas?.Invoke();
        }

        else if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
            QuePasoConLasVidas?.Invoke();
        }
    }
}
