using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool perdio = false;

    public void perderJuego() 
    {
        // Variable por ahora inutil
        perdio = true;
        GameObject.Find("Objetos Mapa").GetComponent<MovimientoMapa>().perderJuego();
    }

    public void recargarJuego() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
