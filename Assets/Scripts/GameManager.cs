using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool started = false, perdio = false;

    public float speedY = 25f;

    float timePassed = 0f, timeSpeed = 1;

    int contador = 1;

    public GameObject panelComienzo;

    public TMP_Text textoReloj, textoSpeed;

    void Start() 
    {
        textoSpeed.text = speedY.ToString();
    }

    void Update()
    {
        if (!started) 
        {
            procesarInicio();
            return;
        }
            
        if (perdio)
            return;

        procesarReloj();   
    }

    void procesarReloj() 
    {
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
        if (segundosPasados == periodoIncremento * contador)
        {
            Debug.Log("[GameManager] Aumentando velocidad luedo de pasados: " + segundosPasados + " segundos.");

            contador++;

            // Mostrar aumento de velocidad en pantalla
            speedY += incrementoVelocidad;
            textoSpeed.text = speedY.ToString();

            // Decir a object spawner que aumente velocidad
            GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().fijarVelocidadA(speedY);
        }
    }

    void procesarInicio() 
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) 
        {
            started = true;
            panelComienzo.SetActive(false);

            MovimientoVerticalObstaculo.started = true;
            GameObject.Find("Bola").GetComponent<BolaManager>().started = true;
            GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().started = true;
            GameObject.Find("Fondo").GetComponent<MovimientoFondo>().started = true;
        }
    }

    public void perderJuego() 
    {
        perdio = true;

        // Decirle al fondo que perdiste
        GameObject.Find("Fondo").GetComponent<MovimientoFondo>().perderJuego();

        // Decirle al object spawner que perdiste
        GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().perderJuego();
    }

    public void recargarJuego() 
    {
        // Recargar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
