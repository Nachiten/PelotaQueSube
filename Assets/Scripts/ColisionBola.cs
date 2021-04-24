using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBola : MonoBehaviour
{
    private void perdioJuego()
    {
        Debug.Log("Perdio Juego!");
        GameObject.Find("GameManager").GetComponent<GameManager>().perderJuego();
        // Destruyo la bola
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[ColisionBola] OnColisionEnter2D");

        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Obstaculo")
            perdioJuego();
    }
}
