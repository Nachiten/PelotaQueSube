using UnityEngine;

public class BolaManager : MonoBehaviour
{
    public bool started = false;

    public bool colisionEnabled = true;

    bool perdio = false;

    void perdioJuego()
    {
        //Debug.Log("Perdio Juego!");
        GameObject.Find("GameManager").GetComponent<GameManager>().perderJuego();

        perdio = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!colisionEnabled || !started)
            return;

        Debug.Log("[BolaManager] Objeto colisionado: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Obstaculo")
            perdioJuego();
    }

    void Start()
    {
        if (!colisionEnabled)
            Debug.LogError("[BolaManager] Colisiones Desactivadas!!!");
    }

    void Update()
    {
        if (perdio || !started)
            return;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        Vector2 posicionActual = transform.position;

        transform.position = new Vector2(mousePos2D.x, posicionActual.y);
    }
}
