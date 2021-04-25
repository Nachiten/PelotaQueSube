using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovimientoBola : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        // Si el rayo hace contacto con un bloque y se tiene el click IZQUIERDO persionado
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("PosX: " + mousePos2D.x);
            //Debug.Log("PosY: " + mousePos2D.y);

            Vector2 posicionActual = transform.position;

            transform.position = new Vector2(mousePos2D.x, posicionActual.y);
        }
    }
}
