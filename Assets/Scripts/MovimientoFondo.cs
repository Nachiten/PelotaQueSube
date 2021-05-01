using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    public bool started = false;

    float speedFondo = 1.5f;

    bool perdio = false;

    float limiteMinimo = -21.6f, sumaAlResetear = 21.6f;

    void Awake()
    {
        // Configurar gravedad
        GetComponent<Rigidbody2D>().gravityScale = 0;

        started = false;
    }

    void Update()
    {
        if (perdio || !started)
            return;

        // Configurar Velocidad
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedFondo);

        Vector2 posicionActual = transform.position;

        // Resetear posicion al pasar cierto limite
        if (posicionActual.y <= limiteMinimo)
            transform.position = new Vector2(posicionActual.x, posicionActual.y + sumaAlResetear);
    }

    public void perderJuego()
    {
        perdio = true;

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
