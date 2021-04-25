using UnityEngine;
using TMPro;

public class MovimientoVertical : MonoBehaviour
{
    float speedY = -10f;

    static bool perdio = false;
    Vector2 posicionInicial;

    public float limiteMinimo = -34f;
    public float sumaAlResetear = 34f;

    public void perderJuego()
    {
        perdio = true;

        // Elimino gravedad para parar de que siga cayendo
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    void Start()
    {
        posicionInicial = transform.position;

        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void Update()
    {
        if (perdio)
            return;

        Vector2 posicionActual = transform.position;

        // Frenar si estoy abajo de todo
        if (posicionActual.y >= posicionInicial.y)
            transform.position = new Vector2(posicionActual.x, posicionInicial.y);

        // Resetear posicion al pasar cierto limite
        if (posicionActual.y <= limiteMinimo) 
        {
            transform.position = new Vector2(posicionActual.x, posicionActual.y + sumaAlResetear);
            posicionInicial = transform.position;
        }

        // Configurar Velocidad
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedY);

    }

    public void aumentarVelocidad(int incremento) 
    {
        speedY -= incremento;
    }
}
