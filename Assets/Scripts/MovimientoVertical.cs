using UnityEngine;
using TMPro;

public class MovimientoVertical : MonoBehaviour
{
    public static bool started = false;

    float speedY = 5f;

    bool perdio = false;

    public bool reseteaPosicion = false;

    public float limiteMinimo = -34f, sumaAlResetear = 34f;

    GameManager codigoGameManager;

    float limiteDesaparicion = -100f; // -20f

    void Awake()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;

        codigoGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        started = false;
    }

    void Update()
    {
        if (perdio || !started)
            return;

        Vector2 posicionActual = transform.position;

        // Resetear posicion al pasar cierto limite
        if (posicionActual.y <= limiteMinimo && reseteaPosicion)
            transform.position = new Vector2(posicionActual.x, posicionActual.y + sumaAlResetear);

        // Configurar Velocidad
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedY);

        if (transform.position.y <= limiteDesaparicion && !reseteaPosicion) 
        {
            GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().ocultarObstaculo(this.gameObject);
            GetComponent<IAplicarColor>().aplicarColorRandom();
        }
    }

    void OnEnable()
    {
        if (gameObject.name == "Fondo")
            speedY = 1.5f;
        else
            speedY = codigoGameManager.speedY;
    }

    void OnDisable()
    {
        pararObjeto();
    }

    public void perderJuego()
    {
        perdio = true;

        pararObjeto();
    }

    void pararObjeto() 
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void fijarVelocidadA(float velocidad)
    {
        if (gameObject.name != "Fondo")
            speedY = velocidad;
    }
}
