using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int animalIndex;
    private int rndXpos;
    private int rndZpos;
    private float startDelay = 2f;
    private float spawnInterval = 5f;

    private GameObject newPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, Random.Range(1f, spawnInterval));
        InvokeRepeating("SpawnRandomAnimalLeft", startDelay, Random.Range(1f, spawnInterval));
        InvokeRepeating("SpawnRandomAnimalRight", startDelay, Random.Range(1f, spawnInterval));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) SpawnRandomAnimal();
        if (Input.GetKeyDown(KeyCode.B)) SpawnRandomAnimalLeft();
        if (Input.GetKeyDown(KeyCode.M)) SpawnRandomAnimalRight();




    }
    public void SpawnRandomAnimal()
    {
        //hacia abajo
        rndXpos = Random.Range(-10, 11);
        animalIndex = Random.Range(0, animalPrefabs.Length);
        newPrefab = Instantiate(animalPrefabs[animalIndex], new Vector3(rndXpos, 0, 20),
                                           animalPrefabs[animalIndex].transform.rotation);
          
    }

    private void SpawnRandomAnimalRight()
    {
        //hacia la derecha
        rndZpos = Random.Range(2, 17);
        animalIndex = Random.Range(0, animalPrefabs.Length);
        animalPrefabs[animalIndex].transform.Rotate(0, -90, 0);
        newPrefab = Instantiate(animalPrefabs[animalIndex], new Vector3(-20, 0, rndZpos),
                                           animalPrefabs[animalIndex].transform.rotation);
        animalPrefabs[animalIndex].transform.Rotate(0, 90, 0);
    }

    private void SpawnRandomAnimalLeft()
    {
        //hacia la izq
        rndZpos = Random.Range(2, 17);
        animalIndex = Random.Range(0, animalPrefabs.Length);
        animalPrefabs[animalIndex].transform.Rotate(0, 90, 0);
        newPrefab = Instantiate(animalPrefabs[animalIndex], new Vector3(20, 0, rndZpos),
                                           animalPrefabs[animalIndex].transform.rotation);
        animalPrefabs[animalIndex].transform.Rotate(0, -90, 0);
    }
}
