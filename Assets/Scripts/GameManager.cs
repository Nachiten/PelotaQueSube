using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool perdio = false;

    float timePassed = 0f;
        
    public float speedY = 25f;

    int contador = 1;

    public TMP_Text textoReloj, textoSpeed;

    void Start() 
    {
        textoSpeed.text = speedY.ToString();
    }

    void Update()
    {
        if (perdio)
            return;

        timePassed += Time.deltaTime;

        string minutes = Mathf.Floor((timePassed % 3600) / 60).ToString("00");
        string seconds = Mathf.Floor(timePassed % 60).ToString("00");
        string miliseconds = Mathf.Floor(timePassed % 6 * 10 % 10).ToString("0");

        textoReloj.text = minutes + ":" + seconds + ":" + miliseconds;

        float incrementoVelocidad = 1.5f;
        int periodoIncremento = 6;

        if (int.Parse(seconds) == periodoIncremento * contador) 
        {
            contador++;

            speedY += incrementoVelocidad;
            textoSpeed.text = speedY.ToString();

            // Aumento la velocidad del fondo
            GameObject.Find("Fondo").GetComponent<MovimientoVertical>().fijarVelocidadA(speedY);

            GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().fijarVelocidadA(speedY);
        }
    }

    public void perderJuego() 
    {
        perdio = true;

        // Decirle al fondo que perdiste
        GameObject.Find("Fondo").GetComponent<MovimientoVertical>().perderJuego();

        // Decirle al object spawner q perdiste
        GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().perderJuego();
    }

    public void recargarJuego() 
    {
        // Recargar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
