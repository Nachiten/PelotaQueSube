using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustadorFondo : MonoBehaviour
{
    int contador = 1;

    void Update()
    {
        Vector2 posicion = transform.position;

        GameObject padre = transform.parent.gameObject;

        if (padre.transform.position.y <= -34f * contador) 
        {
            transform.position = new Vector2(posicion.x, posicion.y += 34f);
            contador++;
        }
            
    }
}
