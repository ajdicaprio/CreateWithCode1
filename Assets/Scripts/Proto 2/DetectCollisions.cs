using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour

{

    private GameManager2 gameManager;   //para referenciar hacia GameManager vidas

    

    // Start is called before the first frame update
    void Start()
    {
        //para referenciar hacia GameManager vidas
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager2>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Game Over");
            //Debug.Log("vidas: " + vidas);
            //para referenciar hacia GameManager vidas
            gameManager.ActualizaVidasRef();


        }

        if (other.CompareTag("Projectile")) 
            //sin el if funcionaría con cualquier colision.
            //ambos tienen collider. El projectile tiene RigidBody
        {
            //Destroy(other.gameObject);

            //Se desactiva para Object Pooler
            gameObject.SetActive(false);

            //Destroy(gameObject); //Ahora es con vidas.
            GetComponent<AnimalHunger>().FeedAnimal(1);

        }


        
    }
}
