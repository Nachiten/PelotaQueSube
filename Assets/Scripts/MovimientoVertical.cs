using UnityEngine;
using TMPro;

public class MovimientoVertical : MonoBehaviour
{
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

        if (transform.position.y <= limiteDesaparicion && !reseteaPosicion)
            GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().ocultarObstaculo(this.gameObject);
        

    }

    void OnEnable()
    {
        //Debug.Log("OnEnable: " + gameObject.name + " | ID: " + gameObject.GetInstanceID());

        speedY = codigoGameManager.speedY;
    }

    void OnDisable()
    {
        //Debug.Log("OnDisable: " + gameObject.name + " | ID: " + gameObject.GetInstanceID());
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
