using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;     //using UnityEngine.UI;
    public int amountToBeFed;
    private int currentFedAmount = 0;

    private GameManager2 gameManager;

    public static event Action SumarUnaVida;


    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager2>();
    }


    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFedAmount;
        if (currentFedAmount >= amountToBeFed)
        {
            Destroy(gameObject, 0.1f); //2do param, time to destroy
            SumarUnaVida?.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
