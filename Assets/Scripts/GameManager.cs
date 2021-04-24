using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool perdio = false;
    List<GameObject> obstaculos;

    void Start() 
    {
        obstaculos = new List<GameObject>();

        GameObject miObstaculo;
        int i = 0;

        while ( (miObstaculo = GameObject.Find("Obstaculo " + i)) != null) {
            obstaculos.Add(miObstaculo);
            i++;
        }

        foreach (GameObject unObstaculo in obstaculos) 
        {
            Debug.Log(unObstaculo);
        }
    }

    public void perderJuego() 
    {
        // Variable por ahora inutil
        perdio = true;
        GameObject.Find("Objetos Mapa").GetComponent<MovimientoMapa>().perderJuego();

        foreach (GameObject unObstaculo in obstaculos) 
        {
            unObstaculo.GetComponent<MovimientoMapa>().perderJuego();
            unObstaculo.GetComponent<MovimientoHorizontalObstaculo>().perdio = true;
        }
    }

    public void recargarJuego() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
