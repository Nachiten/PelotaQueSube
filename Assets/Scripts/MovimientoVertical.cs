using UnityEngine;
using TMPro;

public class MovimientoVertical : MonoBehaviour
{
    float speedY = 5f;

    bool perdio = false;

    public bool reseteaPosicion = false;

    public float limiteMinimo = -34f, sumaAlResetear = 34f;

    GameManager codigoGameManager;

    void Start()
    {
        codigoGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        this.GetComponent<Rigidbody2D>().gravityScale = 0;

        speedY = codigoGameManager.speedY;
    }

    void Update()
    {
        if (perdio)
            return;

        Vector2 posicionActual = transform.position;

        // Resetear posicion al pasar cierto limite
        if (posicionActual.y <= limiteMinimo && reseteaPosicion) 
            transform.position = new Vector2(posicionActual.x, posicionActual.y + sumaAlResetear);
        
        // Configurar Velocidad
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedY);

        if (transform.position.y <= -20f && !reseteaPosicion) 
        {
            codigoGameManager.quitarObstaculo(gameObject);
            Destroy(gameObject);
        }
    }

    public void perderJuego()
    {
        perdio = true;

        // Elimino gravedad para parar de que siga cayendo
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void fijarVelocidadA(float velocidad)
    {
        speedY = velocidad;

        //Debug.Log("[MovimientoVertical] Velocidad Actual: " + speedY);
    }
}
