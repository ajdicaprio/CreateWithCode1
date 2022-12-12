using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX2 : MonoBehaviour
{
    public GameObject dogPrefab;

    //private bool hayUnPerrito; //lo uso si no necesito StopCoroutine
    private Coroutine coroutinePerrito;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (!hayUnPerrito) StartCoroutine(COSpawnDog()); 
            //si deseo parar la CORutina, debo hacerlo con la variable y el null, 
            //sino, solo dispararla, con el bool
            //if (!hayUnPerrito) coroutinePerrito = StartCoroutine(COSpawnDog()); //lo uso si no necesito StopCoroutine
            if (coroutinePerrito == null) coroutinePerrito = StartCoroutine(COSpawnDog()); 
        }
        if (Input.GetKeyDown(KeyCode.V)) //para parar la coroutinePerrito
        {
            if (coroutinePerrito != null) StopCoroutine(coroutinePerrito);
            coroutinePerrito = null;
            //hayUnPerrito = false; //lo uso si no necesito StopCoroutine
        }
    }
    private IEnumerator COSpawnDog()
    {
        //WaitForSeconds waitForSeconds = new WaitForSeconds(4f); //version Trino
        //hayUnPerrito = true; //lo uso si no necesito StopCoroutine
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(4f);  //version normalita sin el WaitForSeconds
        //yield return waitForSeconds; //version Trino
        //
        //hayUnPerrito = false; //lo uso si no necesito StopCoroutine
        coroutinePerrito = null;
    }
}
