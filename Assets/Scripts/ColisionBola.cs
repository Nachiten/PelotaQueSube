using UnityEngine;

public class ColisionBola : MonoBehaviour
{
    void perdioJuego()
    {
        Debug.Log("Perdio Juego!");
        GameObject.Find("GameManager").GetComponent<GameManager>().perderJuego();
        // Destruyo la bola
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[ColisionBola] OnColisionEnter2D");

        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Obstaculo")
            perdioJuego();
    }
}
