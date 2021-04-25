using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool perdio = false;

    List<GameObject> obstaculos;

    float timePassed = 0, velocidad = 5;

    public TMP_Text textoReloj, textoSpeed;

    void Start() 
    {
        obstaculos = new List<GameObject>();

        GameObject miObstaculo;
        int i = 0;

        // Encuentro todos los obstaculos y los agrego a la lista
        while ( ( miObstaculo = GameObject.Find("Obstaculo " + i) ) != null) 
        {
            obstaculos.Add(miObstaculo);
            i++;
        }

        textoSpeed.text = velocidad.ToString();
    }

    int contador = 1;

    private void Update()
    {
        if (perdio)
            return;

        timePassed += Time.deltaTime;

        //float seconds = Mathf.Floor(timePassed % 60);
        //Debug.Log("Tiempo: " + seconds.ToString("F2"));

        string minutes = Mathf.Floor((timePassed % 3600) / 60).ToString("00");
        string seconds = Mathf.Floor(timePassed % 60).ToString("00");
        string miliseconds = Mathf.Floor(timePassed % 6 * 10 % 10).ToString("0");

        textoReloj.text = minutes + ":" + seconds + ":" + miliseconds;

        float incrementoVelocidad = 1.5f;
        int periodoIncremento = 6;

        if (int.Parse(seconds) == periodoIncremento * contador) 
        {
            contador++;

            // Aumento la velocidad del fondo
            GameObject.Find("Fondo").GetComponent<MovimientoVertical>().aumentarVelocidad(incrementoVelocidad);

            // Aumento la velocidad de todos los obstaculos
            foreach (GameObject unObstaculo in obstaculos)
            {
                unObstaculo.GetComponent<MovimientoVertical>().aumentarVelocidad(incrementoVelocidad);
            }

            velocidad += incrementoVelocidad;
            textoSpeed.text = velocidad.ToString();
        }
    }

    public void perderJuego() 
    {
        perdio = true;

        // Decirle al fondo que perdiste
        GameObject.Find("Fondo").GetComponent<MovimientoVertical>().perderJuego();

        // Recorro todos los obstaculos para decirles q perdi
        foreach (GameObject unObstaculo in obstaculos)
        {
            unObstaculo.GetComponent<MovimientoVertical>().perderJuego();
            unObstaculo.GetComponent<MovimientoHorizontalObstaculo>().perdio = true;
        }
    }

    public void recargarJuego() 
    {
        // Recargar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
