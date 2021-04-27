using UnityEngine;

public class MovimientoHorizontalObstaculo : MonoBehaviour
{
    float velocidadObstaculo = 7, posicionLimite = 7.8f;

    int signo = 1;

    bool perdio = false;

    void OnEnable()
    {
        //Debug.Log("OnEnable (movimientoHorizontal): " + gameObject.name);

        float posicionX = Random.Range(-posicionLimite, posicionLimite);

        transform.position = new Vector2(posicionX, 10);
    }

    void Update()
    {
        if (perdio)
            return;

        Vector2 posicionObstaculo = transform.position;
        
        if (posicionObstaculo.x > posicionLimite) 
        {
            //Debug.Log("Paso limite maximo");
            signo = -1;
        }

        if (posicionObstaculo.x < -posicionLimite) 
        {
            //Debug.Log("Paso limite minimo");
            signo = 1;
        }

        this.transform.position = new Vector2(velocidadObstaculo * signo * Time.deltaTime + posicionObstaculo.x, posicionObstaculo.y);
    }

    public void perderJuego() 
    {
        perdio = true;
    }
}
