using UnityEngine;

public class MovimientoVerticalObstaculo : MonoBehaviour
{
    public static bool started = false;

    float speedY = 5f;

    bool perdio = false;

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

        // Configurar Velocidad
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedY);

        // Desaparecer despues de cierto limite
        if (transform.position.y <= limiteDesaparicion) 
        {
            GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().ocultarObstaculo(this.gameObject);
            GetComponent<IAplicarColor>().aplicarColorRandom();
        }
    }

    void OnEnable()
    {
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
        speedY = velocidad;
    }
}
