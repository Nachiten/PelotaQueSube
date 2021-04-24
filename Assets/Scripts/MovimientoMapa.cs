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

    void Update()
    {
        if (perdio)
            return;

        if (transform.position.y >= -2.5f)
            transform.position = new Vector2(0, -2.5f);

        if (Input.GetMouseButtonDown(0))
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    
}
