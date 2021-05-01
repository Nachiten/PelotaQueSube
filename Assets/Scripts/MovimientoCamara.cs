using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject bola;

    float offsetYCamara = 2.6f;

    void Update()
    {
        if (!FindObjectOfType<GameManager>().perdio) 
        {
            Vector3 posicionCamara = transform.position;

            float posicionYBola = bola.GetComponent<Transform>().position.y;

            gameObject.GetComponent<Transform>().position = new Vector3(posicionCamara.x, posicionYBola + offsetYCamara, posicionCamara.z);
        }
    }
}
