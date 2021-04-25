using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject bola;

    private float yMaxBola = 0;

    void Update()
    {
        if (!FindObjectOfType<GameManager>().perdio) 
        {
            Vector3 posicion = gameObject.GetComponent<Transform>().position;

            float posicionYBola = bola.GetComponent<Transform>().position.y;

            if (posicionYBola > yMaxBola)
            {
                yMaxBola = posicionYBola;
                this.gameObject.GetComponent<Transform>().position = new Vector3(posicion.x, yMaxBola, posicion.z);
            }
        }
    }
}
