using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMapa : MonoBehaviour
{
    float speed = -10f;
    public bool perdio = false;

    public void perderJuego() 
    {
        perdio = true;
        // Elimino gravedad para parar de que siga cayendo
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }

    Vector2 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (perdio)
            return;

        Vector2 posicionActual = transform.position;

        if (posicionActual.y >= posicionInicial.y)
            transform.position = new Vector2(posicionActual.x, posicionInicial.y);

        if (Input.GetMouseButtonDown(0))
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    
}
