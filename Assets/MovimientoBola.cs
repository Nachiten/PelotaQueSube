using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBola : MonoBehaviour
{

    public float FuerzaGravedad = 1;
    public float FuerzaY = 500;
    public GameObject Camara;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = FuerzaGravedad;

        if (this.gameObject.GetComponent<Transform>().position.y < Camara.GetComponent<Transform>().position.y - 5.8f) {
            perdioJuego();
        }
    }

    private void perdioJuego()
    {
        Debug.Log("Perdio Juego!");
        FindObjectOfType<GameManager>().perdio = true;
        Destroy(this.gameObject);
    }

    // Utilizar para fuerzas
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {

            float posicionY = this.gameObject.GetComponent<Transform>().position.y;

            // Empujo la bola para arriba
            //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FuerzaY * Time.deltaTime));
            this.gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, FuerzaY * Time.deltaTime + posicionY));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo") {
            perdioJuego();
        }
    }
}
