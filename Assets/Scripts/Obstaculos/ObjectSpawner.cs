using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstaculosPrefabs;

    float limiteMinimo = -10f, sumaAlResetear = 20f;

    float speedY = 5f;
    bool perdio = false;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0;

        speedY = GameObject.Find("GameManager").GetComponent<GameManager>().speedY;
    }

    void Update()
    {
        if (perdio)
            return;

        Vector2 posicionActual = transform.position;

        // Resetear posicion al pasar cierto limite
        if (posicionActual.y <= limiteMinimo)
        {
            transform.position = new Vector2(posicionActual.x, posicionActual.y + sumaAlResetear);

            int numRandom = Random.Range(0, obstaculosPrefabs.Length);

            Debug.Log("[ObjectSpawner] numRandom: " + numRandom);

            GameObject obstaculoInstancia = Instantiate(obstaculosPrefabs[numRandom], new Vector3(0, 10, 0), Quaternion.identity);

            GameObject.Find("GameManager").GetComponent<GameManager>().agregarObstaculo(obstaculoInstancia);
        }

        // Configurar Velocidad
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedY);
    }

    public void perderJuego()
    {
        perdio = true;

        // Elimino gravedad para parar de que siga cayendo
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void fijarVelocidadA(float velocidad)
    {
        speedY = velocidad;

        //Debug.Log("[ObjectSpawner] Velocidad Actual: " + speedY);
    }
}
