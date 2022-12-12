using TMPro;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private int vidas;
    [SerializeField] private TextMeshProUGUI vidasText;

    //Aqui se actualizan las vidas.
    //Esta hecho de 2 maneras:
    //1.- DetectCollision detecta una colision y lo hace con referencias al GameManager y la funcion publica.
    //2.- DestroyOutBound los hace con public static event Action

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        vidasText.text = vidas.ToString();
        if (vidas <= 0) Debug.Log("Game Over!");
    }

    public void SumarUnaVida()
    {
        vidas += 1;
    }

    public void ActualizaVidasRef()
    //public void ActualizaVidasEvento(int arg)  // Si el evento viene con argumento se debe tener aqui igual
    {
        vidas -= 1;
    }

    //3 referencias a esta funcion. Una de PlayerController. Dos correspondientes a los Eventos de DestroyOutBounds.
    public void ActualizaVidasEvento() 
    //public void ActualizaVidasEvento(int arg)  // Si el evento viene con argumento se debe tener aqui igual
    {
        vidas -= 1;
    }

    //Suscripcion a los Eventos
    private void OnEnable()
    {
        DestroyOutOfBounds.QuePasoConLasVidas += ActualizaVidasEvento; //si es con argumento se deja igual
        AnimalHunger.SumarUnaVida += SumarUnaVida;
    }

    private void OnDisable()
    {
        DestroyOutOfBounds.QuePasoConLasVidas -= ActualizaVidasEvento;
        AnimalHunger.SumarUnaVida -= SumarUnaVida;
    }
}
