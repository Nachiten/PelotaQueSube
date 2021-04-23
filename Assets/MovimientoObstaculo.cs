using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    public float velocidadObstaculo;
    int signo = 1;

    void FixedUpdate()
    {
        float posicionX = this.gameObject.GetComponent<Transform>().position.x;

        int posicionLimite = 5;

        if (posicionX > posicionLimite) {
            //Debug.Log("Paso limite maximo");
            signo = -1;
        }

        if (posicionX < -posicionLimite) {
            //Debug.Log("Paso limite minimo");
            signo = 1;
        }

        //Debug.Log("Signo: " + signo);

        this.gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(velocidadObstaculo * signo * Time.deltaTime + posicionX, 0));
    }
}
