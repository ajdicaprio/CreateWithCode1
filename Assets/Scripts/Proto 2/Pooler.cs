using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    
    //VERSION MAS SIMPLE DEL OBJECT POOLER 
    //NO SE ESTA USANDO EN ESTE JUEGO
    
    public static Pooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool; //prefab ref.
    public int amountToPool;        //cantidad

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}

/* PARA UTILIZAR EL POOLER, 
   HACEMOS UN LLAMADO DESDE OTRO SCRIPT 
   POR EJEMPLO DE LA SIGUIENTE MANERA:

if (Input.GetKeyDown(KeyCode.C))
{
  GameObject bullet = Pooler.SharedInstance.GetPooledObject();
  if (bullet != null) 
  {
    bullet.transform.position = transform.position;
    bullet.transform.rotation = transform.rotation;
    bullet.SetActive(true);
   }
} 

PARA DEVOLVER EL OBJETO AL POOLER
gameObject.SetActive(false);
*/
