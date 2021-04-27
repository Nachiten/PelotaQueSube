using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool perdio = false;

    public float speedY = 25f;

    public TMP_Text textoReloj, textoSpeed;

    float timePassed = 0f, timeSpeed = 1;

    int contador = 1;

    void Start() 
    {
        textoSpeed.text = speedY.ToString();
    }

    void Update()
    {
        if (perdio)
            return;

        timePassed += Time.deltaTime * timeSpeed;

        string minutes = Mathf.Floor((timePassed % 3600) / 60).ToString("00");
        string seconds = Mathf.Floor(timePassed % 60).ToString("00");
        string miliseconds = Mathf.Floor(timePassed % 6 * 10 % 10).ToString("0");

        textoReloj.text = minutes + ":" + seconds + ":" + miliseconds;

        float incrementoVelocidad = 1.5f;
        int periodoIncremento = 6;

        int segundosPasados = int.Parse(seconds);

        // Al pegar la vuelta en 1 minuto, vuelvo a resetear el contador
        if (segundosPasados == 59)
            contador = 0;

        // Si pasó un ciclo, aumento la velocidad
        if ( segundosPasados == periodoIncremento * contador) 
        {
            Debug.Log("[GameManager] Aumentando velocidad luedo de pasados: " + segundosPasados + " segundos.");

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
