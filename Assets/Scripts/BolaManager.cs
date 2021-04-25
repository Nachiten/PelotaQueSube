using UnityEngine;

public class BolaManager : MonoBehaviour
{
    bool perdio = false;

    void perdioJuego()
    {
        //Debug.Log("Perdio Juego!");
        GameObject.Find("GameManager").GetComponent<GameManager>().perderJuego();

        perdio = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[ColisionBola] OnColisionEnter2D");

        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Obstaculo")
            perdioJuego();
    }

    void Update()
    {
        if (perdio)
            return;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        // Si el click izquierdo está presionado
        //if (Input.GetMouseButton(0))
        //{
            Vector2 posicionActual = transform.position;

            transform.position = new Vector2(mousePos2D.x, posicionActual.y);
        //}
    }
}
