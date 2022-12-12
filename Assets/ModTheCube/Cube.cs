using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;


    [Header("Config")]
    [SerializeField] private bool activarRotacion;
    [SerializeField] private bool activarScale;

    [Header("Rotacion")]
    [SerializeField] private Vector3 anguloRotacion;
    [SerializeField] private float velocidadRotacion;

    [Header("Scale")]
    [SerializeField] private Vector3 scaleInicial;
    [SerializeField] private Vector3 scaleFinal;
    [SerializeField] private float velocidadScale;
    [SerializeField] private float scaleRatio;
    private float tiempoScale;
    private bool scaleSuperior;

    private float timer = 0;

    void Start()
    {
        //transform.position = new Vector3(3, 4, 1);
        //transform.localScale = Vector3.one * 1.0f;

        Material material = Renderer.material;
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.5f);

    }

    void Update()
    {
        if (activarRotacion) //animacion de rotacion
        {
            transform.Rotate(anguloRotacion * velocidadRotacion * Time.deltaTime);
        }

        if (activarScale) //animacion de agrandar-reducir 
        {
            tiempoScale += Time.deltaTime;
            if (scaleSuperior)
            {
                transform.localScale = Vector3.Lerp(transform.localScale,
                                                    scaleFinal,
                                                    velocidadScale * Time.deltaTime);
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale,
                                                    scaleInicial,
                                                    velocidadScale * Time.deltaTime);
            }

                      
            if (tiempoScale >= scaleRatio)
            {
                scaleSuperior = !scaleSuperior;
                tiempoScale = 0;
            }

        
        }
        timer += Time.deltaTime;

        if (timer >= 4f)
        {
            Material material = Renderer.material;

            material.color = new Color(Rnd(), Rnd(), Rnd(), Mathf.Clamp(Rnd(),0.5f,1f));

            timer = 0f;


        }



    }

    private float Rnd()
    {
        return Random.Range(0f, 100f)/100f;
    }
}




//incrementar tamaño
//public Vector3 scaleChange;

//incrementar posicion
//public Vector3 positionChange;

//rotación
//public Vector3 rotateChange;


//void Update()
    //transform.localScale += scaleChange;
    //transform.position += positionChange;
    //transform.Rotate(rotateChange);

