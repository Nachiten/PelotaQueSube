using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBola : MonoBehaviour
{
    //public float FuerzaGravedad = 1;
    //public float FuerzaY = 500;
    //public GameObject Camara;

    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -2.5f)
            transform.position = new Vector2(0, -2.5f);

        if (Input.GetMouseButtonDown(0))
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    private void perdioJuego()
    {
        Debug.Log("Perdio Juego!");
        FindObjectOfType<GameManager>().perdio = true;
        Destroy(this.gameObject);
    }

    //// Utilizar para fuerzas
    //void FixedUpdate()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {

    //        float posicionY = this.gameObject.GetComponent<Transform>().position.y;

    //        // Empujo la bola para arriba
    //        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FuerzaY * Time.deltaTime));
    //        this.gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, FuerzaY * Time.deltaTime + posicionY));
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo") {
            perdioJuego();
        }
    }
}
