using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    float velocidadObstaculo = 0; // 3
    int signo = 1;

    void FixedUpdate()
    {
        Vector2 posicionObstaculo = GetComponent<Transform>().position;

        //Debug.Log("Posicion ObstaculoY: " + posicionObstaculo.y);

        int posicionLimite = 5;

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

        //Debug.Log("Signo: " + signo);

        this.transform.position = new Vector2(velocidadObstaculo * signo * Time.deltaTime + posicionObstaculo.x, posicionObstaculo.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("[MovimientoObstaculo] OnColisionEnter2D");
    }
}
