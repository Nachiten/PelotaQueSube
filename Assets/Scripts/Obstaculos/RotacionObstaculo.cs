using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionObstaculo : MonoBehaviour
{
    float rotacionActual = 0;
    float speed = 170f;

    bool perdio = false;

    void Update()
    {
        if (perdio)
            return;

        Quaternion rotacion = Quaternion.Euler(0, 0, rotacionActual);

        this.transform.rotation = rotacion;

        rotacionActual += speed * Time.deltaTime;
    }

    public void perderJuego() 
    {
        perdio = true;
    }
}
