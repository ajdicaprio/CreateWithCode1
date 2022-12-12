using UnityEngine;

public class PlayerController2 : MonoBehaviour

{

    public float horizontalInput;
    public float verticalInput;
    float horizontalSpeed = 20f;
    public float xRange = 10.5f;

    public GameObject projectilePrefab;

    private bool onMovement;


    // Start is called before the first frame update
    void Start()
    {
                                      
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * horizontalSpeed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xRange, xRange), transform.position.y, transform.position.z);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * horizontalSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -1, 12));


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        
        Vector3 nuevaPos = new Vector3(10, 0, 0);
        if (Input.GetKeyDown(KeyCode.C) || onMovement)
        {
            onMovement = true;
            //ult parametro. Lerp es un %. MoveTowards es distancia maxima.
            //transform.position = Vector3.Lerp(transform.position, nuevaPos, Time.deltaTime * horizontalSpeed);
            transform.position = Vector3.MoveTowards(transform.position, nuevaPos, Time.deltaTime * horizontalSpeed * 4f);
            if (transform.position == nuevaPos) onMovement = false;
        }

        
    }

    

}
