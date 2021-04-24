using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVerticalObstaculo : MonoBehaviour
{
    void Update()
    {
        Vector2 posicion = transform.position;

        if (posicion.y <= -10f)
        {
            transform.position = new Vector2(posicion.x, posicion.y += 40f);
        }

    }
}
