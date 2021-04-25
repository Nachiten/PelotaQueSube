using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamañoObstaculo : MonoBehaviour
{
    float speed = 4.5f, signo = 1, tamañoLimiteMax = 5, tamañoLimiteMin = 0.5f;

    bool perdio = false;

    void Update()
    {
        if (perdio)
            return;

        Vector2 tamañoObstaculo = transform.localScale;

        if (tamañoObstaculo.x > tamañoLimiteMax)
        {
            //Debug.Log("Paso limite maximo");
            signo = -1;
        }

        if (tamañoObstaculo.x < tamañoLimiteMin)
        {
            //Debug.Log("Paso limite minimo");
            signo = 1;
        }

        this.transform.localScale = new Vector2(tamañoObstaculo.x + speed * Time.deltaTime * signo, tamañoObstaculo.y + speed * Time.deltaTime * signo * 2);
    }

    public void perderJuego()
    {
        perdio = true;
    }
}
